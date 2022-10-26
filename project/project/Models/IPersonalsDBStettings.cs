namespace project.Models
{
    public interface IPersonalsDBStettings
    {
        public string PersonalsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
