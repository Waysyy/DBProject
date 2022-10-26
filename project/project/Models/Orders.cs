using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace project.Models
{
    public class Orders
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("client")]
        public string Client { get; set; } = String.Empty;
        [BsonElement("dateOrd")]
        public string DateOrd { get; set; } = String.Empty;
        [BsonElement("price")]
        public int Price { get; set; }
    }
}
