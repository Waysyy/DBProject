using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace projectFront.Models
{
    public class Cakes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } =   String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("type")]
        public string Type { get; set; } = String.Empty;
        [BsonElement("weight")]
        public string Weight { get; set; } = String.Empty;
        [BsonElement("price")]
        public int Price { get; set; }
        [BsonElement("ingredients")]
        public string[]? Ingredients { get; set; }
    }
}
