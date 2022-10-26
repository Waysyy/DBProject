using MongoDB.Driver;
using project.Models;

namespace project.Services
{
    public class PersonalsServise: IPersonalsServise
    {
        private readonly IMongoCollection<Personals> _personals;

        public PersonalsServise(IPersonalsDBStettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _personals = database.GetCollection<Personals>(settings.PersonalsCollectionName);
        }


        public Personals Create(Personals personals)
        {
            _personals.InsertOne(personals);
            return personals;
        }

        public List<Personals> Get()
        {
            return _personals.Find(personals => true).ToList();
        }

        public Personals Get(string id)
        {
            return _personals.Find(personals => personals.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _personals.DeleteOne(personals => personals.Id == id);
        }

        public void Update(string id, Personals personals)
        {
            _personals.ReplaceOne(personals => personals.Id == id, personals);
        }
    }
}
