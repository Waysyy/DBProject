using project.Models;

namespace project.Services
{
    public interface ICakesServise
    {
        List<Cakes> Get();
        Cakes Get(string id);
        Cakes Create(Cakes cakes);
        void Update(string id, Cakes cakes);
        void Remove(string id);
    }
}
