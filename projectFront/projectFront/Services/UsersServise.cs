using projectFront.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace projectFront.Services
{
    public class UsersServise : IUsersServise
    {
        public readonly IMongoCollection<Users> _user;
        public MongoClient client = new MongoClient("mongodb+srv://way:way@cluster0.ztgw56g.mongodb.net/?retryWrites=true&w=majority");
        
        public UsersServise()
        {
           
            var db = client.GetDatabase("project");
            _user = db.GetCollection<Users>("users");

        }
      

        public Users Get(string login, string password)
        {
            
            return _user.Find(user => user.Login == login && user.Password == password).FirstOrDefault();
            
        }

        public Users GetToken(long token)
        {

            return _user.Find(user => user.Token == token).FirstOrDefault();

        }

        public void Auth(string login, string password)
        {

            
        }

        public void Update(string login, BsonDocument token)
        {
            
            _user.UpdateOneAsync(user => user.Login == login, token);
        }
    }
}
