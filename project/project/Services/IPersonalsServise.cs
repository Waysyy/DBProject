using project.Models;

namespace project.Services
{
    public interface IPersonalsServise
    {
        List<Personals> Get();
        Personals Get(string id);
        Personals Create(Personals personals);
        void Update(string id, Personals personals);
        void Remove(string id);
    }
}
