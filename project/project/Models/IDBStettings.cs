namespace project.Models
{
    public interface IDBStettings
    {
        public string PersonalsCollectionName { get; set; } 
        public string OrdersCollectionName { get; set; }
        public string IngredientsCollectionName { get; set; }
        public string CakesCollectionName { get; set; }
        public string ClientsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
