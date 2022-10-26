using MongoDB.Driver;
using project.Models;

namespace project.Services
{
    public class IngredientsServise: IIngredientsServise
    {
        private readonly IMongoCollection<Ingredients> _ingredients;

        public IngredientsServise(IDBStettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _ingredients = database.GetCollection<Ingredients>(settings.IngredientsCollectionName);
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
