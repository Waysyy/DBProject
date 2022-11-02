namespace project.Models
{
    public class DBStettings: IDBStettings
    {
        public string UsersCollectionName { get; set; } = String.Empty;
        public string PersonalsCollectionName { get; set; } = String.Empty;
        public string OrdersCollectionName { get; set; } = String.Empty ;
        public string IngredientsCollectionName { get; set; } = String.Empty;
        public string CakesCollectionName { get; set; } = String.Empty;
        public string ClientsCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
