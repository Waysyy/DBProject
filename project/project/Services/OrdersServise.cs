using MongoDB.Driver;
using project.Models;

namespace project.Services
{
    public class OrdersServise: IOrdersServise
    {
        private readonly IMongoCollection<Orders> _orders;

        public OrdersServise(IOrdersDBStettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Orders>(settings.OrdersCollectionName);
        }


        public Orders Create(Orders orders)
        {
            _orders.InsertOne(orders);
            return orders;
        }

        public List<Orders> Get()
        {
            return _orders.Find(orders => true).ToList();
        }

        public Orders Get(string id)
        {
            return _orders.Find(orders => orders.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _orders.DeleteOne(orders => orders.Id == id);
        }

        public void Update(string id, Orders orders)
        {
            _orders.ReplaceOne(orders => orders.Id == id, orders);
        }
    }

}
