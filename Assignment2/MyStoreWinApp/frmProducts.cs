using BusinessObject;
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

namespace MyStoreWinApp
{
    public partial class frmProducts : Form
    {
        IProductRepository productRepository = new ProductRepository();
        public frmProducts()
        {
            InitializeComponent();
        }

        private void loadProducts()
        {
            dvgProducts.DataSource = productRepository.GetProducts().Select(x => new
            {
                ProductId = x.ProductId,
                CategoryId = x.CategoryId,
                ProductName= x.ProductName,
                Weight = x.Weight,
                UnitPrice = x.UnitPrice,
                InStock = x.UnitInStock
            }).ToList();
        }

        private void clearText()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtCate.Text = string.Empty;
            txtStock.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text != null && txtCate.Text != null)
            {
                int productId, categoryId;
                if(Int32.TryParse(txtId.Text, out productId) && Int32.TryParse(txtCate.Text, out categoryId))
                {
                    Product prodcut = new Product
                    {
                        ProductId = productId,
                        CategoryId = categoryId,
                        ProductName = txtName.Text,
                        Weight = txtWeight.Text,
                        UnitPrice = Decimal.Parse(txtPrice.Text),
                        UnitInStock = Int32.Parse(txtStock.Value.ToString())
                    };
                    productRepository.addProduct(prodcut);
                    loadProducts();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text != null && txtCate.Text != null)
            {
                int productId, categoryId;
                if (Int32.TryParse(txtId.Text, out productId) && Int32.TryParse(txtCate.Text, out categoryId))
                {
                    Product prodcut = new Product
                    {
                        ProductId = productId,
                        CategoryId = categoryId,
                        ProductName = txtName.Text,
                        Weight = txtWeight.Text,
                        UnitPrice = Decimal.Parse(txtPrice.Text),
                        UnitInStock = Int32.Parse(txtStock.Value.ToString())
                    };
                    productRepository.updateProdcut(prodcut);
                    loadProducts();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtId.Text != null)
            {
                int productId;
                if(Int32.TryParse(txtId.Text, out productId))
                {
                    productRepository.deleteProduct(productId);
                    loadProducts();
                }
            }
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void dvgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int productId = int.Parse(dvgProducts.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                Product product = productRepository.GetProduct(productId);
                txtId.Text = product.ProductId.ToString();
                txtCate.Text = product.CategoryId.ToString();
                txtName.Text = product.ProductName.ToString();
                txtPrice.Text = product.UnitPrice.ToString();
                txtWeight.Text = product.Weight.ToString();
                txtStock.Value = Decimal.Parse(product.UnitInStock.ToString());
            }
        }
    }
}
