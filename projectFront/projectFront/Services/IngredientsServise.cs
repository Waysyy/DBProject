using MongoDB.Driver;
using projectFront.Models;
using System.Collections.Generic;

namespace projectFront.Services
{
    public class IngredientsServise: IIngredientsServise
    {
        private readonly IMongoCollection<Ingredients> _ingredients;
        public MongoClient client = new MongoClient("mongodb+srv://way:way@cluster0.ztgw56g.mongodb.net/?retryWrites=true&w=majority");
        public IngredientsServise()
        {
            var db = client.GetDatabase("project");
            _ingredients = db.GetCollection<Ingredients>("ingredients");
        }

        

        public Ingredients Create(Ingredients ingredients)
        {
            _ingredients.InsertOne(ingredients);
            return ingredients;
        }

        public List<Ingredients> Get()
        {
            return _ingredients.Find(ingredients => true).ToList();
        }

        public Ingredients Get(string id)
        {
            return _ingredients.Find(ingredients => ingredients.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _ingredients.DeleteOne(ingredients => ingredients.Id == id);
        }

        public void Update(string id, Ingredients ingredients)
        {
            _ingredients.ReplaceOne(ingredients => ingredients.Id == id, ingredients);
        }
    }
}
