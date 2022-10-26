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
        public string ExplorationDate { get; set; } = String.Empty;
        [BsonElement("inStock")]
        public int InStock { get; set; }
        
    }
}
