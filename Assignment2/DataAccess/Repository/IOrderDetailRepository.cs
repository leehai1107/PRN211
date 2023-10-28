using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        public OrderDetail GetOrderDetail(int orderId, int productId);
        public void updateOrderDetail(OrderDetail orderDetail);
        public List<OrderDetail> GetOrderDetails();
        public void AddOrderDetail(OrderDetail orderDetail);
    }
}
