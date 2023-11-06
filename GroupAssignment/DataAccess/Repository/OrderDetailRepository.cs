using BussinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        OrderDetailDAO orderDetailDAO = new OrderDetailDAO();

        public List<OrderDetail> GetOrderDetails() => orderDetailDAO.GetOrderDetails();

        public OrderDetail GetOrderDetail(int productId, int orderId) => orderDetailDAO.GetOrderDetail(productId, orderId);

        public void AddOrderDetail(OrderDetail orderDetail) => orderDetailDAO.AddOrderDetail(orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail) => orderDetailDAO.UpdateOrderDetail(orderDetail);
        public void DeleteOrderDetail(int productId, int orderId) => orderDetailDAO.DeleteOrderDetail(productId, orderId);
    }
}
