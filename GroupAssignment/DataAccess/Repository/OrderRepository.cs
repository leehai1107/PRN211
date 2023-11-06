using BussinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        OrderDAO orderDAO = new OrderDAO();
        public List<Order> GetOrders() => orderDAO.GetOrders();
        public Order GetOrder(int id) => orderDAO.GetOrder(id);
        public void AddOrder(Order order) => orderDAO.AddOrder(order);
        public void UpdateOder(Order order) => orderDAO.UpdateOrder(order);
        public void DeleteOrder(int id) => orderDAO.DeleteOrder(id);
    }
}
