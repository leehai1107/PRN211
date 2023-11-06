using BussinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RoleRepository : IRoleRepository
    {
        RoleDAO roleDAO = new RoleDAO();
        public List<Role> GetRoles() => roleDAO.GetRoles();
        public Role GetRole(int id) => roleDAO.GetRole(id);
    }
}
