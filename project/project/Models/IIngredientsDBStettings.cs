namespace project.Models
{
    public interface IIngredientsDBStettings
    {
        public string IngredientsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
