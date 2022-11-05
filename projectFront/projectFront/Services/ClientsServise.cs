using MongoDB.Driver;
using projectFront.Models;
using System.Collections.Generic;

namespace projectFront.Services
{
    public class ClientsServise: IClientsServise
    {
        private readonly IMongoCollection<Clients> _clients;
        public MongoClient client = new MongoClient("mongodb+srv://way:way@cluster0.ztgw56g.mongodb.net/?retryWrites=true&w=majority");
        public ClientsServise()
        {
            var db = client.GetDatabase("project");
            _clients = db.GetCollection<Clients>("clients");
        }

        

        public Clients Create(Clients clients)
        {
            _clients.InsertOne(clients);
            return clients;
        }

        public List<Clients> Get()
        {
            return _clients.Find(clients => true).ToList();
        }

        public Clients Get(string id)
        {
            return _clients.Find(clients => clients.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _clients.DeleteOne(clients => clients.Id == id);
        }

        public void Update(string id, Clients clients)
        {
            _clients.ReplaceOne(clients => clients.Id == id, clients);
        }
    }
}
