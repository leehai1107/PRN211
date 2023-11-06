using BussinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDAO = new ProductDAO();

        public List<Product> GetProducts() => productDAO.GetProducts();

        public Product GetProduct(int id) => productDAO.GetProduct(id);

        public void AddProduct(Product product) => productDAO.AddProduct(product);

        public void UpdateProduct(Product product) => productDAO.UpdateProduct(product);

        public void DeleteProduct(int id) => productDAO.DeleteProduct(id);
    }
}
