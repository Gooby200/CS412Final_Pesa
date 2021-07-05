using CS412Final_Pesa.DAL;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.Repositories {
    public class OrderRepository : IOrderRepository {
        public Order CreateOrder(Order order) {
            return OrderDAL.CreateOrder(order);
        }

        public bool DeleteOrder(long orderId) {
            return OrderDAL.DeleteOrder(orderId);
        }

        public List<Order> GetCompletedOrders() {
            return OrderDAL.GetCompletedOrders();
        }

        public Order GetOrder(long orderId) {
            return OrderDAL.GetOrder(orderId);
        }

        public long GetOrderCount() {
            return OrderDAL.GetOrderCount();
        }

        public List<Order> GetOrdersByCustomerName(string partialName) {
            return OrderDAL.GetOrdersByCustomerName(partialName);
        }

        public List<long> GetOrderedByUserIds(List<long> orderIds) {
            return OrderDAL.GetOrderedByUserIds(orderIds);
        }

        public List<Order> GetOrders(long userId = -1) {
            return OrderDAL.GetOrders(userId);
        }
    }
}