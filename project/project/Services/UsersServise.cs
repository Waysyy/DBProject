using project.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace project.Services
{
    public class UsersServise : IUsersServise
    {
        public readonly IMongoCollection<Users> _user;

        public UsersServise(IDBStettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _user = database.GetCollection<Users>(settings.UsersCollectionName);
        }
      

        public Users Get(string login)
        {
            
            return _user.Find(user => user.Login == login).FirstOrDefault();
            
        }

        public Users GetToken(string token)
        {

            return _user.Find(user => user.Token == token).FirstOrDefault();

        }

        public void Auth(string login)
        {

            
        }

        public void Update(string login, BsonDocument token)
        {
            
            _user.UpdateOneAsync(user => user.Login == login, token);
        }
    }
}
