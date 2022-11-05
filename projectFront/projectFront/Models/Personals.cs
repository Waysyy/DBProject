using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
namespace projectFront.Models
{
    public class Personals
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("lastname")]
        public string Lastname { get; set; } = String.Empty;
        [BsonElement("jobTitle")]
        public string JobTitle { get; set; } = String.Empty;
        [BsonElement("salary")]
        public int Salary { get; set; }
        [BsonElement("manager")]
        public string Manager { get; set; } = String.Empty;
    }
}
