using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetOrders() => OrderDAO.Instance.GetOrders();

        public Order GetOrder(int orderId) => OrderDAO.Instance.getOrderById(orderId);

        public void updateOrder(Order order) => OrderDAO.Instance.updateOrder(order);

        public void addOrder(Order order) => OrderDAO.Instance.addOrder(order);

        public void deleteOrder(int orderId) => OrderDAO.Instance.deleteOrder(orderId);
    }
}
