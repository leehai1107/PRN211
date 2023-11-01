using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public List<OrderDetail> GetOrderDetails()
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                return context.OrderDetails.Include(x => x.Order).Include(x => x.Product).ToList();
            }
        }

        public OrderDetail getAnOrderDetail(int orderId, int productId)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                return context.OrderDetails.Include(od => od.Product).SingleOrDefault(o => o.OrderId == orderId && o.ProductId == productId);
            }
        }

        public void updateOrderDetail(OrderDetail orderDetail)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                context.OrderDetails.Update(orderDetail);
                context.SaveChanges();
            }
        }

        public void addOrderDetail(OrderDetail orderDetail)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
        }

        public void deleteOrderDetail(int orderId, int productId)
        {
            using(Assignment2Context context = new Assignment2Context())
            {
                OrderDetail orderDetail = getAnOrderDetail(orderId, productId);
                context.OrderDetails.Remove(orderDetail);
                context.SaveChanges();
            }
        }
    }
}
