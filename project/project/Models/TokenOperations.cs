using MongoDB.Bson;
using MongoDB.Bson.IO;
using Newtonsoft;
using project.Models;

namespace project
{
    
    public class TokenOperations
    {
        Users user = new Users();

        public void ChangeToken()
        {

        }

        public long GetToken()
        {
            return user.Token;
        }
    }
}
