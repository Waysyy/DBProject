using MongoDB.Bson;
using project.Models;

namespace project.Services
{
    public interface ITokenService
    {
        public List<Tokens> Get();
       
        void Update(long token1, BsonDocument token);

        
    }
}
