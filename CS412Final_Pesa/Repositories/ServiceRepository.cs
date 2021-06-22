using CS412Final_Pesa.DAL;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.Repositories {
    public class ServiceRepository : IServiceRepository {
        public void AssociateOrderToServices(long orderId, List<long> serviceIds) {
            ServiceDAL.AssociateOrderToServices(orderId, serviceIds);
        }

        public Service CreateService(Service service) {
            return ServiceDAL.CreateService(service);
        }

        public bool DeleteOrderServices(long orderId) {
            return ServiceDAL.DeleteOrderServices(orderId);
        }

        public List<OrderServices> GetOrderServices(List<long> orderIds) {
            return ServiceDAL.GetOrderServices(orderIds);
        }

        public List<Service> GetServices() {
            return ServiceDAL.GetServices();
        }
    }
}