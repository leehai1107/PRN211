using BussinessObjects.Models;
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
        public Order GetOrder(int id);
        public void AddOrder(Order order);
        public void UpdateOder(Order order);
        public void DeleteOrder(int id);
    }
}
