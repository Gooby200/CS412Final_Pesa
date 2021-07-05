using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.Repositories.Interfaces {
    public interface IOrderRepository {
        List<Order> GetOrders(long userId = -1);
        Order GetOrder(long orderId);
        long GetOrderCount();
        List<Order> GetCompletedOrders();
        Order CreateOrder(Order order);
        bool DeleteOrder(long orderId);
        List<long> GetOrderedByUserIds(List<long> orderIds);
        List<Order> GetOrdersByCustomerName(string partialName);
    }
}