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

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
      

        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
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
            userServise.Update(username, token);
            userServise.Update(username, validDate);
            tokenOperations.Invoke(encodedJwt);


            return Json(response);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = userServise.Get(username, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Login)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
