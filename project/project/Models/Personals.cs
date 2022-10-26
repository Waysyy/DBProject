using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace project.Models
{
    public class Personals
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("type")]
        public string Type { get; set; } = String.Empty;
        [BsonElement("weight")]
        public int Weight { get; set; }
        [BsonElement("price")]
        public int Price { get; set; }
        [BsonElement("ingredients")]
        public string[]? Ingredients { get; set; }
    }
}
