using MongoDB.Driver;
using projectFront.Models;
using System.Collections.Generic;

namespace projectFront.Services
{
    public class OrdersServise: IOrdersServise
    {
        private readonly IMongoCollection<Orders> _orders;
        public MongoClient client = new MongoClient("mongodb+srv://way:way@cluster0.ztgw56g.mongodb.net/?retryWrites=true&w=majority");
        public OrdersServise()
        {
            var db = client.GetDatabase("project");
            _orders = db.GetCollection<Orders>("orders");
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
