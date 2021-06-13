using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.DAL {
    public static class OrderDAL {
        private static List<Order> _orders = new List<Order>() {
            new Order() {
                Id = 1,
                CustomerName = "Gaston Pesa",
                ServiceDate = DateTime.Now.AddDays(-1),
                Services = new List<Service>() {
                    new Service() {
                        Id = 1,
                        Name = "Mowing",
                        Price = 25.00M
                    },
                    new Service() {
                        Id = 3,
                        Name = "Tree Trimming",
                        Price = 100.00M
                    }
                }
            },
            new Order() {
                Id = 2,
                CustomerName = "Gaston Pesa",
                ServiceDate = DateTime.Now.AddDays(1),
                Services = new List<Service>() {
                    new Service() {
                        Id = 1,
                        Name = "Mowing",
                        Price = 25.00M
                    }
                }
            },
            new Order() {
                Id = 3,
                CustomerName = "Gaston Pesa",
                ServiceDate = DateTime.Now.AddDays(1),
                Services = new List<Service>() {
                    new Service() {
                        Id = 2,
                        Name = "Cleanup",
                        Price = 250.00M
                    }
                }
            }
        };

        public static List<Order> GetOrders() {
            return _orders;
        }
    }
}