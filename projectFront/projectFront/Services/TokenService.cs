using projectFront.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace projectFront.Services
{
    public class TokenService : ITokenService
    {
        public readonly IMongoCollection<Tokens> _token;

        /*public TokenService()
        {
            Get();
        }*/
        public MongoClient client = new MongoClient("mongodb+srv://way:way@cluster0.ztgw56g.mongodb.net/?retryWrites=true&w=majority");
        public TokenService()
        {
            var db = client.GetDatabase("project");
            _token = db.GetCollection<Tokens>("tokens");
        }

       

        public List<Tokens> Get()
        {
            return _token.Find(token => true).ToList();
        }

        public void Update(long tokenAuth, BsonDocument tokenchange)
        {

            _token.UpdateOneAsync(token => token.Token == tokenAuth, tokenchange);
        }
    }
}
