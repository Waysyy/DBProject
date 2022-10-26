namespace project.Models
{
    public class ClientsDBStettings: IClientsDBStettings
    {
        public string ClientsCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
