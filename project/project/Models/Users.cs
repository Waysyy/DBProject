using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace project.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } =   String.Empty;
        [BsonElement("login")]
        public string Login { get; set; } = String.Empty;
        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;
        [BsonElement("token")]
        public long Token { get; set; }
        [BsonElement("tokenDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime TokenDate { get; set; }

    }
}
