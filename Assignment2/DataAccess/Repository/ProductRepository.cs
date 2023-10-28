using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository:IProductRepository
    {
        public List<Product> GetProducts() => ProductDAO.Instance.GetProducts();

        public Product GetProduct(int productId) => ProductDAO.Instance.getProductById(productId);

        public void addProduct(Product product) => ProductDAO.Instance.AddProduct(product);

        public void updateProdcut(Product product) => ProductDAO.Instance.UpdateProduct(product);

        public void deleteProduct(int productId) => ProductDAO.Instance.DeleteProduct(productId);
    }
}
