namespace project.Models
{
    public class OrdersDBStettings : IOrdersDBStettings
    {
        public string OrdersCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
