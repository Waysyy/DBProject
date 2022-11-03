using project.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace project.Services
{
    public class TokenService : ITokenService
    {
        public readonly IMongoCollection<Tokens> _token;

        public TokenService()
        {
            Get();
        }

        public TokenService(IDBStettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _token = database.GetCollection<Tokens>(settings.TokensCollectionName);
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
