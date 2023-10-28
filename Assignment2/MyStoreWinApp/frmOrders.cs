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
    public partial class frmOrders : Form
    {
        IOrderRepository orderRepository = new OrderRepository();
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        IProductRepository productRepository = new ProductRepository();

        public frmOrders()
        {
            InitializeComponent();
            
        }

        private float caculateTotal(int freight, int unitPrice, int quantity, float discount)
        {
            float moneyDiscount = (unitPrice * quantity) *discount/100;
            return (freight + ((unitPrice * quantity) - moneyDiscount));
        }

        private void loadProduct()
        {
            cbProduct.DataSource = productRepository.GetProducts();
            cbProduct.ValueMember = "ProductId";
            cbProduct.DisplayMember = "ProductName";
        }

        private void loadOrder()
        {
            dgvOrder.DataSource = orderDetailRepository.GetOrderDetails().Select(x => new
            {
                OrderID = x.OrderId,
                ProductId = x.Product.ProductId, // Store the ProductId separately
                MemberID = x.Order.MemberId,
                Total = caculateTotal(x.Order.Freight != null ? (int)x.Order.Freight : 0, (int)x.Product.UnitPrice,
                (int)x.Quantity, (float)x.Discount).ToString()
            }).ToList();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            loadOrder();
            loadProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get the values from the form
            int orderId = Convert.ToInt32(txtId.Text);
            int productId = Convert.ToInt32(cbProduct.SelectedValue);
            int memberId = Convert.ToInt32(txtMemberId.Text);
            float unitPrice = float.Parse(txtUnitPrice.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            float discount = float.Parse(txtDiscount.Text);

            // Create a new order or update an existing order
            Order order;
            if (orderId == 0)
            {
                // Create a new order
                order = new Order()
                {
                    MemberId = memberId,
                    Freight = null,  // Set the appropriate value for Freight
                    OrderDate = DateTime.Now,  // Set the order date
                    RequiredDate = checkReqDate.Checked ? null : (DateTime?)requiredDate.Value,  // Set the required date if not checked
                    ShippedDate = checkShipDate.Checked ? null : (DateTime?)shippedDate.Value  // Set the shipped date if not checked
                };
                orderRepository.addOrder(order);
                orderId = order.OrderId;  // Retrieve the generated order ID
            }
            else
            {
                // Update an existing order
                order = orderRepository.GetOrder(orderId);
                order.MemberId = memberId;
                order.RequiredDate = checkReqDate.Checked ? null : (DateTime?)requiredDate.Value;  // Set the required date if not checked
                order.ShippedDate = checkShipDate.Checked ? null : (DateTime?)shippedDate.Value;  // Set the shipped date if not checked
                orderRepository.updateOrder(order);
            }

            // Create a new order detail or update an existing order detail
            OrderDetail orderDetail = orderDetailRepository.GetOrderDetail(orderId, productId);
            if (orderDetail == null)
            {
                // Create a new order detail
                orderDetail = new OrderDetail()
                {
                    OrderId = orderId,
                    ProductId = productId,
                    UnitPrice = (decimal)unitPrice,
                    Quantity = quantity,
                    Discount = discount
                };
                orderDetailRepository.AddOrderDetail(orderDetail);
            }
            else
            {
                // Update an existing order detail
                orderDetail.UnitPrice = (decimal)unitPrice;
                orderDetail.Quantity = quantity;
                orderDetail.Discount = discount;
                orderDetailRepository.updateOrderDetail(orderDetail);
            }

            // Refresh the order list and clear the form
            loadOrder();
            clearData();
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvOrder.SelectedRows[0];
                int orderId = Convert.ToInt32(selectedRow.Cells["OrderID"].Value);
                int productId = Convert.ToInt32(selectedRow.Cells["ProductId"].Value);

                Order order = orderRepository.GetOrder(orderId);
                OrderDetail orderDetail = orderDetailRepository.GetOrderDetail(orderId,productId);
                txtId.Text = order.OrderId.ToString();
                txtUnitPrice.Text = orderDetail.UnitPrice.ToString();
                txtMemberId.Text = order.MemberId.ToString();
                cbProduct.SelectedValue = orderDetail.ProductId;
                txtQuantity.Text = orderDetail.Quantity.ToString();
                txtDiscount.Text = orderDetail.Discount.ToString();
                txtFreight.Text = order.Freight.ToString();
                orderDate.Value = order.OrderDate;
               if(order.RequiredDate!= null)
                {
                    requiredDate.Value = (DateTime)order.RequiredDate;
                }
                else
                {
                    checkReqDate.Checked = true;
                }
                
                if(order.ShippedDate!= null)
                {
                    shippedDate.Value = (DateTime)order.ShippedDate;
                }
                else
                {
                    checkShipDate.Checked = true;
                }

            }
        }

        private void clearData()
        {
            txtId.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtFreight.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtMemberId.Text= string.Empty;
            checkReqDate.Checked = false;
            checkShipDate.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productId;

            if (int.TryParse(cbProduct.SelectedValue.ToString(), out productId))
            {
                Product product = productRepository.GetProduct(productId);
                // Rest of your code to work with the 'product' object
                txtUnitPrice.Text = product.UnitPrice.ToString();
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the values from the form
            int orderId = Convert.ToInt32(txtId.Text);
            int productId = Convert.ToInt32(cbProduct.SelectedValue);
            int memberId = Convert.ToInt32(txtMemberId.Text);
            float unitPrice = float.Parse(txtUnitPrice.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            float discount = float.Parse(txtDiscount.Text);

            // Update the existing order
            Order order = orderRepository.GetOrder(orderId);
            order.MemberId = memberId;
            order.RequiredDate = checkReqDate.Checked ? null : (DateTime?)requiredDate.Value;  // Set the required date if not checked
            order.ShippedDate = checkShipDate.Checked ? null : (DateTime?)shippedDate.Value;  // Set the shipped date if not checked
            orderRepository.updateOrder(order);

            // Update the existing order detail
            OrderDetail orderDetail = orderDetailRepository.GetOrderDetail(orderId, productId);
            orderDetail.UnitPrice = (decimal)unitPrice;
            orderDetail.Quantity = quantity;
            orderDetail.Discount = discount;
            orderDetailRepository.updateOrderDetail(orderDetail);

            // Refresh the order list and clear the form
            loadOrder();
            clearData();
        }

    }
}
