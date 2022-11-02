using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using project.Models;
using project.Services;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {

        public long UserToken;

        

        private readonly IUsersServise userServise;

        public UsersController(IUsersServise userServise)
        {
            this.userServise = userServise;
        }


        [HttpGet("{login}")]
        public ActionResult<Users> Get(string login, string password)
        {
            var user = userServise.Get(login,password);
            if (user == null)
            {
                return NotFound($"Пользователь с login = {login} не найден ");
            }
            if (user.TokenDate > DateTime.Today)
            {
                Random rnd = new Random();
                long value = rnd.Next(100000000, 199999999);
                var token = new BsonDocument("$set", new BsonDocument("token", value));

                DateTime date = new DateTime(DateTime.Today.Year+1, DateTime.Today.Month, DateTime.Today.Day);
                var tokenDate = new BsonDocument("$set", new BsonDocument("tokenDate", date));

                userServise.Update(login, token);
                userServise.Update(login, tokenDate);
            }
            return user;
            
        }

        

    }
}
