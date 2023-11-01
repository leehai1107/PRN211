using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public OrderDetail GetOrderDetail(int orderId, int productId) => OrderDetailDAO.Instance.getAnOrderDetail(orderId,productId);

        public void updateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.updateOrderDetail(orderDetail);

        public List<OrderDetail> GetOrderDetails() => OrderDetailDAO.Instance.GetOrderDetails();

        public void AddOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.addOrderDetail(orderDetail);

        public void deleteOrderDetail(int orderId, int productId) => OrderDetailDAO.Instance.deleteOrderDetail(orderId,productId);
    }
}
