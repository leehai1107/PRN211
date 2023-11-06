using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        public List<Order> GetOrders()
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Orders.ToList();
            }
        }

        public Order GetOrder(int id)
        {
            using (DemoContext context = new DemoContext())
            {
                return context.Orders.SingleOrDefault(o => o.OrderId == id);
            }
        }

        public void AddOrder(Order order)
        {
            using (DemoContext context = new DemoContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            using (DemoContext context = new DemoContext())
            {
                context.Orders.Remove(GetOrder(id));
                context.SaveChanges();
            }
        }

        public void UpdateOrder(Order order)
        {
            using (DemoContext context = new DemoContext())
            {
                context.Orders.Update(order);
                context.SaveChanges();
            }
        }
    }
}
