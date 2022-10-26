namespace project.Models
{
    public interface ICakesDBStettings
    {
        public string CakesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
