using project.Models;

namespace project.Services
{
    public interface IClientsServise
    {
        List<Clients> Get();
        Clients Get(string id);
        Clients Create(Clients clients);
        void Update(string id, Clients clients);
        void Remove(string id);
    }
}
