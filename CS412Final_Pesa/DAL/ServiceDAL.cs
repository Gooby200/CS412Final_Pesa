using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.DAL {
    public static class ServiceDAL {
        private static List<Service> _services = new List<Service>() {
            new Service() {
                Id = 1,
                Name = "Mowing",
                Price = 25.00M
            },
            new Service() {
                Id = 2,
                Name = "Cleanup",
                Price = 250.00M
            },
            new Service() {
                Id = 3,
                Name = "Tree Trimming",
                Price = 100.00M
            }
        };

        public static List<Service> GetServices() {
            return _services;
        }

        public static Service CreateService(Service service) {
            //get the latest id from the services
            Service lastService = _services.LastOrDefault();
            service.Id = lastService.Id + 1;
            _services.Add(service);

            return service;
        }
    }
}