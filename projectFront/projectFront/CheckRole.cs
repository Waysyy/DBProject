using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectFront
{
    public class CheckRole
    {
        public string RoleChecker()
        {
            string role = System.IO.File.ReadAllText("role.txt");

            return role;
        }
        

    }
}
