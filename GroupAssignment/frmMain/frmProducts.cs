using BussinessObjects.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmWinApp
{
    public partial class frmProducts : Form
    {
        IProductRepository productRepository = new ProductRepository();
        ICategoryRepository categoryRepository = new CategoryRepository();
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadProducts()
        {
            dgvProducts.DataSource = productRepository.GetProducts().Select(x => new
            {
                ProductID = x.ProductId,
                ProductName = x.ProductName,
                Category = x.Category.CategoryName,
                Weight = x.Weight,
                UnitPrice = x.UnitPrice,
                UnitInStock = x.UnitInStock
            }).ToList();
        }
        private void LoadCategories()
        {
            cbCategory.DataSource = categoryRepository.GetCategories();
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryId";
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {

                int productId = Int32.Parse(dgvProducts.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                Product product = productRepository.GetProduct(productId);
                txtProductId.Text = product.ProductId.ToString();
                txtProductName.Text = product.ProductName.ToString();
                txtUnitPrice.Text = product.UnitPrice.ToString();
                txtWeight.Text = product.Weight.ToString();
                cbCategory.SelectedValue = product.CategoryId;
                nudUnitInStock.Value = product.UnitInStock;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                ProductId = Int32.Parse(txtProductId.Text),
                ProductName = txtProductName.Text,
                CategoryId = Int32.Parse(cbCategory.SelectedValue.ToString()),
                Weight= txtWeight.Text,
                UnitPrice = Decimal.Parse(txtUnitPrice.Text),
                UnitInStock = Int32.Parse(nudUnitInStock.Value.ToString())
            };
            productRepository.UpdateProduct(product);
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                ProductId = Int32.Parse(txtProductId.Text),
                ProductName = txtProductName.Text,
                CategoryId = Int32.Parse(cbCategory.SelectedValue.ToString()),
                Weight = txtWeight.Text,
                UnitPrice = Decimal.Parse(txtUnitPrice.Text),
                UnitInStock = Int32.Parse(nudUnitInStock.Value.ToString())
            };
            productRepository.AddProduct(product);
            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ProductId = Int32.Parse(txtProductId.Text);
            productRepository.DeleteProduct(ProductId);
            LoadProducts();
        }
    }
}
