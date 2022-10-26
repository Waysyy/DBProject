namespace project.Models
{
    public interface IClientsDBStettings
    {
        public string ClientsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
