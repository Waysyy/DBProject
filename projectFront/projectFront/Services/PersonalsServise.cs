using MongoDB.Driver;
using projectFront.Models;
using System.Collections.Generic;

namespace projectFront.Services
{
    public class PersonalsServise: IPersonalsServise
    {
        private readonly IMongoCollection<Personals> _personals;
        public MongoClient client = new MongoClient("mongodb+srv://way:way@cluster0.ztgw56g.mongodb.net/?retryWrites=true&w=majority");
        public PersonalsServise()
        {
            var db = client.GetDatabase("project");
            _personals = db.GetCollection<Personals>("personals");
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
