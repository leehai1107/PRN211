using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CategoryDAO
    {
        public List<Category> GetCategories()
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetCategory(int id)
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Categories.SingleOrDefault(c => c.CategoryId == id);
            }
        }
    }
}
