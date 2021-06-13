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
        public OrderBLL() {
            _orderRepository = new OrderRepository();
        }

        public decimal GetMoneyCollected() {
            decimal moneyCollected = 0;
            foreach (Order order in _orderRepository.GetOrders())
                if (order.ServiceDate < DateTime.Now)
                    moneyCollected += order.Total;

            return moneyCollected;

            //return _orderRepository.GetOrders().Where(x => x.ServiceDate < DateTime.Now).Sum(x => x.Total);
        }

        public List<Order> GetOrders() {
            return _orderRepository.GetOrders();
        }
    }
}