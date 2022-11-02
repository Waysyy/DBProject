using MongoDB.Bson;
using project.Models;

namespace project.Services
{
    public interface IUsersServise
    {
        
        Users Get(string login, string password);
       
        void Update(string login, BsonDocument token);

        void Auth(string login, string password);
    }
}
