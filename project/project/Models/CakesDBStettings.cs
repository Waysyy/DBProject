namespace project.Models
{
    public class CakesDBStettings: ICakesDBStettings
    {
       public string CakesCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
