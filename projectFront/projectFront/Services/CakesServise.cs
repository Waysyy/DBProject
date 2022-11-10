using projectFront.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace projectFront.Services
{
    public class CakesServise : ICakesServise
    {
        private readonly IMongoCollection<Cakes> _cakes;
        public MongoClient client = new MongoClient("mongodb+srv://way:way@cluster0.ztgw56g.mongodb.net/?retryWrites=true&w=majority");
        public CakesServise()
        {
            var db = client.GetDatabase("project");
            _cakes = db.GetCollection<Cakes>("cakes");
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
            try
            {
               return _cakes.Find(cakes => cakes.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
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
