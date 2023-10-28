using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders();
        public Order GetOrder(int orderId);
        public void updateOrder(Order order);
        public void addOrder(Order order);
        public void deleteOrder(int orderId);
    }
}
