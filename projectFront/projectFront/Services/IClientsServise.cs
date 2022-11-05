using projectFront.Models;
using System.Collections.Generic;

namespace projectFront.Services
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
