using MongoDB.Bson;
using projectFront.Models;
using System.Collections.Generic;

namespace projectFront.Services
{
    public interface IUsersServise
    {
        
         Users Get(string login, string password);
       
        void Update(string login, BsonDocument token);

        void Auth(string login, string password);

        public Users GetToken(long token);
    }
}
