using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace project.Models
{
    public class Clients
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("lastname")]
        public string Lastname { get; set; } = String.Empty;
        
    }
}
