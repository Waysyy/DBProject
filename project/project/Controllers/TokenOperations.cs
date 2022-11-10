using Microsoft.AspNetCore.Http.Headers;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft;
using project.Models;
using project.Services;
using System.Net;

namespace project.Controllers
{

    public class TokenOperations
    {
        //public IMongoCollection<Tokens> _token;
        public IMongoCollection<Users> _user;

        public MongoClient client = new MongoClient("mongodb+srv://way:way@cluster0.ztgw56g.mongodb.net/?retryWrites=true&w=majority");

        /*public List<Tokens> Get()
        {

            var db = client.GetDatabase("project");
            _token = db.GetCollection<Tokens>("tokens");

            return _token.Find(token => true).ToList();
        }


        public void Update(long tokenAuth, BsonDocument tokenchange)
        {

            var db = client.GetDatabase("project");
            _token = db.GetCollection<Tokens>("tokens");
            _token.UpdateOneAsync(token => token.Token == tokenAuth, tokenchange);
        }*/
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



        public TokenOperations(){}
        public bool GetGroup()
        {

            /*
                        Tokens token;
                        List<Tokens> TList = Get();
                        if(TList[0].Valid <= DateTime.Now)
                        {
                            long value = 1;
                            var Newtoken = new BsonDocument("$set", new BsonDocument("token", value));
                            Update(TList[0].Token, Newtoken);
                        }
                        TList = Get();*/
            //long GettedToken = TList[0].Token;


            Authorization authorization = new Authorization();

            Users UserToken = GetToken("");
            
            string login = UserToken.Login;
            if (login == "admin")
                return true;
            else
                return false;
        }

    }
}
