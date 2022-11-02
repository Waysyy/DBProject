using project.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace project.Services
{
    public class UsersServise : IUsersServise
    {
        private readonly IMongoCollection<Users> _user;

        public UsersServise(IDBStettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _user = database.GetCollection<Users>(settings.UsersCollectionName);
        }


       

        public Users Get(string login, string password)
        {
            
            return _user.Find(user => user.Login == login && user.Password == password).FirstOrDefault();
            
        }

       public void Auth(string login, string password)
        {

            
        }

        public void Update(string id, BsonDocument token)
        {
            
            _user.UpdateOneAsync(user => user.Id == id, token);
        }
    }
}
