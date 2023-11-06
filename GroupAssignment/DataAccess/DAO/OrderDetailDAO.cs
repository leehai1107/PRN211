using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        public List<OrderDetail> GetOrderDetails()
        {
            using (DemoContext context = new DemoContext())
            {
                return context.OrderDetails.Include(o => o.Product).Include(o => o.Order).ToList();
            }
        }

        public OrderDetail GetOrderDetail(int productId, int orderId)
        {
            using(DemoContext context = new DemoContext())
            {
                return context.OrderDetails.Include(o => o.Product).Include(o => o.Order).SingleOrDefault(o => o.ProductId == productId && o.OrderId == orderId);
            }
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            using (DemoContext context = new DemoContext())
            {
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
        }

        public void DeleteOrderDetail(int productId, int orderId)
        {
            using (DemoContext context = new DemoContext())
            {
                context.OrderDetails.Remove(GetOrderDetail(productId, orderId));
                context.SaveChanges();
            }
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            using (DemoContext context = new DemoContext())
            {
                context.OrderDetails.Update(orderDetail);
                context.SaveChanges();
            }
        }
    }
}
