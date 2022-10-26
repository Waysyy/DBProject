using project.Models;

namespace project.Services
{
    public interface IIngredientsServise
    {
        List<Ingredients> Get();
        Ingredients Get(string id);
        Ingredients Create(Ingredients ingredients);
        void Update(string id, Ingredients ingredients);
        void Remove(string id);
    }
}
