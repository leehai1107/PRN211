using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoleDAO
    {
        public List<Role> GetRoles()
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Roles.ToList();
            }
        }

        public Role GetRole(int id)
        {
            using(DemoContext context = new DemoContext())
            {
                return context.Roles.SingleOrDefault(r => r.RoleId == id);
            }
        }
    }
}
