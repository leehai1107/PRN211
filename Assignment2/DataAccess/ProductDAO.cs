using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Product> GetProducts()
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                return context.Products.ToList();
            }
        }

        public Product getProductById(int id)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                return (Product)context.Products.SingleOrDefault(p => p.ProductId == id);
            }
        }

        public void AddProduct(Product product)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                Product pro = getProductById(product.ProductId);
                if (pro == null)
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                
            }
        }

        public void UpdateProduct(Product product)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                Product pro= getProductById(product.ProductId);
                if(pro!=null)
                {
                    context.Update(product);
                    context.SaveChanges();
                }
                
            }
        }

        public void DeleteProduct(int id)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                context.Products.Remove(getProductById(id));
                context.SaveChanges();
            }
        }

    }
}
