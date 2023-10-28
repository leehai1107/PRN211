using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Order> GetOrders()
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                return context.Orders.ToList();
            }
        }

        public Order getOrderById(int id)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                return context.Orders.SingleOrDefault(o => o.OrderId == id);
            }
        }

        public void deleteOrder(int id)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                Order obj = getOrderById(id);
                if(obj != null)
                {
                    context.Orders.Remove(obj);
                }
                else
                {
                    throw new Exception("Can not find the Order!");
                }
            }
        }

        public void updateOrder(Order order)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                Order findOrder = getOrderById(order.OrderId);
                if (findOrder != null)
                {
                    context.Orders.Update(order);
                }
            }
        }

        public void addOrder(Order order)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                Order findOrder = getOrderById(order.OrderId);
                if(findOrder == null)
                {
                    context.Orders.Add(order);
                }
            }
        }

    }
}
