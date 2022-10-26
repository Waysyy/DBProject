namespace project.Models
{
    public interface ICakesDBStettings
    {
        string CakesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
