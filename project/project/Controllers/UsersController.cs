using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using project.Models;
using project.Services;
using Newtonsoft.Json.Linq;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {


        public string userAuth = "";
        

        private readonly IUsersServise userServise;

        public UsersController(IUsersServise userServise)
        {
            this.userServise = userServise;
        }

        TokenOperations tokenOperations = new TokenOperations();

        [HttpGet("{login}")]
        public ActionResult<Users> Get(string login, string password)
        {
            var user = userServise.Get(login,password);
            if (user == null)
            {
                return NotFound($"Пользователь с login = {login} не найден ");
            }
            if (user.TokenDate == DateTime.Today)
            {
                Random rnd = new Random();
                long value = rnd.Next(100000000, 199999999);
                var Newtoken = new BsonDocument("$set", new BsonDocument("token", value));

                DateTime date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, (DateTime.Today.Day+2));
                var tokenDate = new BsonDocument("$set", new BsonDocument("tokenDate", date));

                userServise.Update(login, Newtoken);
                userServise.Update(login, tokenDate);
                List<Tokens> TList = tokenOperations.Get();
                long GettedToken = TList[0].Token;
                tokenOperations.Update(GettedToken, Newtoken);

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
             


        }
        /*[HttpGet("{token}")]
        public ActionResult<Users> GetToken(long tokenAuth)
        {
            var user = userServise.GetToken(tokenAuth);
            if (user == null)
            {
                return NotFound($"Пользователь не найден ");
            }

            userAuth = user.Login;
            return user;



        }
*/
    }
}
