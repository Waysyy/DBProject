using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using projectFront.Models;
using projectFront.Services;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Graph;

namespace projectFront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {


        public UsersController() { }


         UsersServise userServise = new UsersServise();

        

        public UsersController(UsersServise userServise)
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
            var validDate1 = new BsonDocument("$set", new BsonDocument("valid", user.TokenDate));
            tokenOperations.Update(TokList[0].Token, validDate1);
            if (lastUser != currentUser)
            {
                var lastuser = new BsonDocument("$set", new BsonDocument("token", user.Token));
                var Newtoken = new BsonDocument("$set", new BsonDocument("lastUser", user.Login));
                List<Tokens> TList = tokenOperations.Get();
                long GettedToken = TList[0].Token;
                tokenOperations.Update(GettedToken, Newtoken);
                tokenOperations.Update(GettedToken, lastuser);
            }
            if (TokList[0].Token == 1)
            {
                var lastuser = new BsonDocument("$set", new BsonDocument("token", user.Token));
                var Newtoken = new BsonDocument("$set", new BsonDocument("lastUser", user.Login));
                List<Tokens> TList = tokenOperations.Get();
                long GettedToken = TList[0].Token;
                tokenOperations.Update(GettedToken, Newtoken);
                tokenOperations.Update(GettedToken, lastuser);
            }

            return user;
             


        }
        
    }
}
