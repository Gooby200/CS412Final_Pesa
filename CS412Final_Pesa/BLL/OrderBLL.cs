using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS412Final_Pesa.BLL {
    public class OrderBLL : IOrderBLL {
        private readonly IOrderRepository _orderRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IUserRepository _userRepository;

        public OrderBLL() {
            _orderRepository = new OrderRepository();
            _serviceRepository = new ServiceRepository();
            _userRepository = new UserRepository();
        }

        public Order CreateOrder(Order order, List<long> serviceIds) {
            // save the order
            order = _orderRepository.CreateOrder(order);

            //associate order with the services
            _serviceRepository.AssociateOrderToServices(order.Id, serviceIds);

            order = AssociateServicesWithOrders(new List<Order> { order }).FirstOrDefault();
            AssociateUsersWithOrders(new List<Order>() { order });

            return order;
        }

        public List<Order> GetCompletedOrders() {
            List<Order> orders = AssociateServicesWithOrders(_orderRepository.GetCompletedOrders());
            AssociateUsersWithOrders(orders);
            return orders;
        }

        public decimal GetMoneyCollected() {
            decimal moneyCollected = 0;
            foreach (Order order in _orderRepository.GetOrders())
                if (order.ServiceDate < DateTime.Now)
                    moneyCollected += order.PaidAmount;

            return moneyCollected;
        }

        public long GetOrderCount() {
            return _orderRepository.GetOrderCount();
        }

        public List<Order> GetOrders(long userId = -1) {
            List<Order> orders = AssociateServicesWithOrders(_orderRepository.GetOrders(userId));
            AssociateUsersWithOrders(orders);
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

        private void AssociateUsersWithOrders(List<Order> orders) {
            //get list of users that belong to the orders
            List<User> users = _userRepository.GetUsers(orders.Select(x => x.OrderedById).ToList());

            foreach (Order o in orders) {
                User u = users.FirstOrDefault(x => x.Id == o.OrderedById);
                if (u != null) {
                    o.OrderedBy = u;
                }
            }
        }

        public Order GetOrder(long orderId) {
            Order order = _orderRepository.GetOrder(orderId);
            if (order != null) {
                order = AssociateServicesWithOrders(new List<Order> { order }).FirstOrDefault();
                AssociateUsersWithOrders(new List<Order> { order });
            }

            return order;
        }

        public Order ModifyOrder(Order order, List<long> serviceIds) {
            try {
                //TODO implement order modification

                if (serviceIds?.Count > 0) {
                    //implement change services for the order
                }

                return order;
            } catch (Exception ex) {
                return null;
            }
        }

        public List<Order> GetOrdersByCustomerName(string partialName) {
            List<Order> orders = AssociateServicesWithOrders(_orderRepository.GetOrdersByCustomerName(partialName));
            AssociateUsersWithOrders(orders);
            return orders;
        }
    }
}