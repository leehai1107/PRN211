using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public Product GetProduct(int productId);
        public void addProduct(Product product);
        public void updateProdcut(Product product);
        public void deleteProduct(int productId);
    }
}
