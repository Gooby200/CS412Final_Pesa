using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.BLL {
    public class OrderBLL : IOrderBLL {
        public readonly IOrderRepository _orderRepository;
        public readonly IServiceRepository _serviceRepository;

        public OrderBLL() {
            _orderRepository = new OrderRepository();
            _serviceRepository = new ServiceRepository();
        }

        public Order CreateOrder(Order order, List<long> serviceIds) {
            // get the services that the user selected
            List<Service> services = _serviceRepository.GetServices().Where(x => serviceIds.Contains(x.Id)).ToList();

            //assign those services to the order
            order.Services = services;

            // save the order
            return _orderRepository.CreateOrder(order);
        }

        public List<Order> GetCompletedOrders() {
            return _orderRepository.GetCompletedOrders();
        }

        public decimal GetMoneyCollected() {
            decimal moneyCollected = 0;
            foreach (Order order in _orderRepository.GetOrders())
                if (order.ServiceDate < DateTime.Now)
                    moneyCollected += order.Total;

            return moneyCollected;

            //return _orderRepository.GetOrders().Where(x => x.ServiceDate < DateTime.Now).Sum(x => x.Total);
        }

        public long GetOrderCount() {
            return _orderRepository.GetOrderCount();
        }

        public List<Order> GetOrders() {
            return _orderRepository.GetOrders();
        }
    }
}