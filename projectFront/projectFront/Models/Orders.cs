using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Reflection.Metadata;
using System;
namespace projectFront.Models
{
    [BsonIgnoreExtraElements]
    public class Orders
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("client")]
        public string Client { get; set; } = String.Empty;
        [BsonElement("dateOrd")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DateOrd { get; set; }

        [BsonElement("cook")]
        public string Cook { get; set; } = String.Empty;
        [BsonElement("cake")]
        public string Cake { get; set; } = String.Empty;

        [BsonElement("price")]
        public int Price { get; set; }
    }
}
