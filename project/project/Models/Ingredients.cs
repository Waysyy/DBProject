using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace project.Models
{
    public class Ingredients
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("explorationDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ExplorationDate { get; set; }
        [BsonElement("inStock")]
        public string InStock { get; set; } = String.Empty;

    }
}
