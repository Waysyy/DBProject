using MongoDB.Bson;
using projectFront.Models;
using System.Collections.Generic;

namespace projectFront.Services
{
    public interface ITokenService
    {
        public List<Tokens> Get();
       
        void Update(long token1, BsonDocument token);

        
    }
}
