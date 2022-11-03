﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace project.Models
{
    public class Tokens
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } =   String.Empty;
        [BsonElement("token")]
        public long Token { get; set; }
        [BsonElement("lastUser")]
        public string LastUser { get; set; } = String.Empty;
    }
}
