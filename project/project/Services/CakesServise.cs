using project.Models;
using MongoDB.Driver;

namespace project.Services
{
    public class CakesServise : ICakesServise
    {
        private readonly IMongoCollection<Cakes> _cakes;

        public CakesServise(ICakesDBStettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _cakes = database.GetCollection<Cakes>(settings.CakesCollectionName);
        }


        public Cakes Create(Cakes cakes)
        {
            _cakes.InsertOne(cakes);
            return cakes;
        }

        public List<Cakes> Get()
        {
            return _cakes.Find(cakes => true).ToList();
        }

        public Cakes Get(string id)
        {
            return _cakes.Find(cakes => cakes.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
             _cakes.DeleteOne(cakes => cakes.Id == id);
        }

        public void Update(string id, Cakes cakes)
        {
            _cakes.ReplaceOne(cakes => cakes.Id == id, cakes);
        }
    }
}
