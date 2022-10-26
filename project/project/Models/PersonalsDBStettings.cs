namespace project.Models
{
    public class PersonalsDBStettings:IPersonalsDBStettings
    {
        public string PersonalsCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
