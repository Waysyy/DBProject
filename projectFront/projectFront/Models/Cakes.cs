using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace projectFront.Models
{
    public class Cakes
    {
        
        public string Id { get; set; } =   String.Empty;
        
        public string Name { get; set; } = String.Empty;
       
        public string Type { get; set; } = String.Empty;
        
        public string Weight { get; set; } = String.Empty;
        
        public int Price { get; set; }
        
        public string[]? Ingredients { get; set; }
    }
}
