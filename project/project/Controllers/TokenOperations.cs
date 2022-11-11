using Microsoft.AspNetCore.Http.Headers;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft;
using project.Models;
using project.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Principal;
using System.Text;

namespace project.Controllers
{

    public class TokenOperations
    {
        //public IMongoCollection<Tokens> _token;
        public IMongoCollection<Users> _user;

        public MongoClient client = new MongoClient("mongodb+srv://way:way@cluster0.ztgw56g.mongodb.net/?retryWrites=true&w=majority");

       
        public Users GetToken(string token)
        {

            var db = client.GetDatabase("project");
            _user = db.GetCollection<Users>("users");
            return _user.Find(user => user.Token == token).FirstOrDefault();

        }


        public string authToken;
        public string Invoke(string token)
        {
            authToken = token;
            return token;
        }

        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        //private readonly IUserService _userService;

        public TokenOperations(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
            
        }
        public string JWTToken(string token)
        {
            return token;
        }


        public TokenOperations(){}
        public bool GetGroup(string token)
        {

            Users UserToken = GetToken(token);
            
            string login = UserToken.Login;
            if (login == "admin")
                return true;
            else
                return false;
        }

    }
}
