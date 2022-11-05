using projectFront.Models;
using System.Collections.Generic;

namespace projectFront.Services
{
    public interface IOrdersServise
    {
        List<Orders> Get();
        Orders Get(string id);
        Orders Create(Orders orders);
        void Update(string id, Orders orders);
        void Remove(string id);
    }
}
