using MongoDB.Driver;
using project.Models;

namespace project.Services
{
    public class ClientsServise: IClientsServise
    {
        private readonly IMongoCollection<Clients> _clients;

        public ClientsServise(IClientsDBStettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _clients = database.GetCollection<Clients>(settings.ClientsCollectionName);
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
