using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        public List<Product> GetProducts()
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Products.Include(p => p.Category).ToList();
            }
        }

        public Product GetProduct(int id)
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Products.SingleOrDefault(p => p.ProductId == id);
            }
        }

        public void AddProduct(Product product)
        {
            using (DemoContext context = new DemoContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (DemoContext context = new DemoContext())
            {
                Product product = GetProduct(id);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (DemoContext context = new DemoContext())
            {
                context.Products.Update(product);
                context.SaveChanges();
            }
        }
    }
}
