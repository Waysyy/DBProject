using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using project.Models;
using project.Services;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;

using System.Security.Claims;
using System;
using DnsClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Models;

namespace project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {



        private readonly IUsersServise userServise;

        public UsersController(IUsersServise userServise)
        {
            this.userServise = userServise;
        }

        TokenOperations tokenOperations = new TokenOperations();

        /*[HttpGet("{login}")]
        public ActionResult<Users> Get(string login, string password)
        {
            var user = userServise.Get(login, password);
            if (user == null)
            {
                return NotFound($"Пользователь с login = {login} не найден ");
            }
            if (user.TokenDate == DateTime.Today)
            {
                Random rnd = new Random();
                long value = rnd.Next(100000000, 199999999);
                var Newtoken = new BsonDocument("$set", new BsonDocument("token", value));

                DateTime date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, (DateTime.Today.Day + 2));
                var tokenDate = new BsonDocument("$set", new BsonDocument("tokenDate", date));
                var validDate = new BsonDocument("$set", new BsonDocument("valid", date));
                userServise.Update(login, Newtoken);
                userServise.Update(login, tokenDate);
                List<Tokens> TList = tokenOperations.Get();
                long GettedToken = TList[0].Token;
                tokenOperations.Update(GettedToken, Newtoken);
                tokenOperations.Update(GettedToken, validDate);
            }
            List<Tokens> TokList = tokenOperations.Get();
            string lastUser = TokList[0].LastUser;
            string currentUser = user.Login;

            if (lastUser != currentUser)
            {
                var lastuser = new BsonDocument("$set", new BsonDocument("token", user.Token));
                var Newtoken = new BsonDocument("$set", new BsonDocument("lastUser", user.Login));
                List<Tokens> TList = tokenOperations.Get();
                long GettedToken = TList[0].Token;
                tokenOperations.Update(GettedToken, Newtoken);
                tokenOperations.Update(GettedToken, lastuser);
            }
            
            //GetToken(user.Token);
             return user;



        }*/
        public class LoginModel
        {
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }
        }

        


        [HttpPost("/token")]
        public IActionResult Token([FromBody] LoginModel loginModel)
        {
            var identity = GetIdentity(loginModel.UserName, loginModel.Password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: Authorization.ISSUER,
                    audience: Authorization.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(Authorization.LIFETIME)),
                    signingCredentials: new SigningCredentials(Authorization.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };


            DateTime date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, (DateTime.Today.Day + 2));
            var token = new BsonDocument("$set", new BsonDocument("token", encodedJwt));
            var validDate = new BsonDocument("$set", new BsonDocument("tokenDate", date));
            userServise.Update(loginModel.UserName, token);
            userServise.Update(loginModel.UserName, validDate);
            tokenOperations.Invoke(encodedJwt);
            

            return Json(response);
        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            
            
            return Convert.ToBase64String(dst);
        }
        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }
        private ClaimsIdentity GetIdentity(string username, string password)
        {
            /*var token = new BsonDocument("$set", new BsonDocument("password", HashPassword(password)));
            userServise.Update(username, token);*/
            var user = userServise.Get(username);
            VerifyHashedPassword(user.Password, password);
            if (VerifyHashedPassword(user.Password, password) == true)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class AuthorizeAttribute : Attribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var account = (LoginModel)context.HttpContext.Items["User"];
                if (account == null)
                {
                    // not logged in
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                }
            }
        }
    }
}
