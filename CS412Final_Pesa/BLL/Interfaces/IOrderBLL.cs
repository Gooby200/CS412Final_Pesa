using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS412Final_Pesa.BLL.Interfaces {
    public interface IOrderBLL {
        decimal GetMoneyCollected();
        List<Order> GetOrders(long userId = -1);
        Order GetOrder(long orderId);
        long GetOrderCount();
        List<Order> GetCompletedOrders();
        Order CreateOrder(Order order, List<long> serviceIds);
        bool DeleteOrder(long orderId);
        Order ModifyOrder(Order order, List<long> serviceIds);
        List<Order> GetOrdersByCustomerName(string partialName);
    }
}
