using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS412Final_Pesa.BLL {
    public class OrderBLL : IOrderBLL {
        public readonly IOrderRepository _orderRepository;
        public readonly IServiceRepository _serviceRepository;

        public OrderBLL() {
            _orderRepository = new OrderRepository();
            _serviceRepository = new ServiceRepository();
        }

        public Order CreateOrder(Order order, List<long> serviceIds) {
            // save the order
            order = _orderRepository.CreateOrder(order);

            //associate order with the services
            _serviceRepository.AssociateOrderToServices(order.Id, serviceIds);

            order = AssociateServicesWithOrders(new List<Order> { order }).FirstOrDefault();

            return order;
        }

        public List<Order> GetCompletedOrders() {
            List<Order> orders = AssociateServicesWithOrders(_orderRepository.GetCompletedOrders());
            return orders;
        }

        public decimal GetMoneyCollected() {
            decimal moneyCollected = 0;
            foreach (Order order in _orderRepository.GetOrders())
                if (order.ServiceDate < DateTime.Now)
                    moneyCollected += order.PaidAmount;

            return moneyCollected;

            //return _orderRepository.GetOrders().Where(x => x.ServiceDate < DateTime.Now).Sum(x => x.Total);
        }

        public long GetOrderCount() {
            return _orderRepository.GetOrderCount();
        }

        public List<Order> GetOrders() {
            List<Order> orders = AssociateServicesWithOrders(_orderRepository.GetOrders());            
            return orders;
        }

        public bool DeleteOrder(long orderId) {
            //delete the orderservices
            bool orderServicesDeleted = _serviceRepository.DeleteOrderServices(orderId);

            //delete the order
            bool orderDeleted = _orderRepository.DeleteOrder(orderId);

            return orderServicesDeleted && orderDeleted;
        }

        private List<Order> AssociateServicesWithOrders(List<Order> orders) {
            List<OrderServices> orderServices = _serviceRepository.GetOrderServices(orders.Select(x => x.Id).ToList());

            foreach (OrderServices os in orderServices) {
                Order o = orders.FirstOrDefault(x => x.Id == os.OrderId);
                if (o.Services == null)
                    o.Services = new List<Service>();

                orders.FirstOrDefault(x => x.Id == os.OrderId).Services.Add(os.Service);
            }

            return orders;
        }
    }
}