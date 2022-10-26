namespace project.Models
{
    public class IngredientsDBStettings: IIngredientsDBStettings
    {
        public string IngredientsCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
