using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.BLL {
    public class ServiceBLL : IServiceBLL {
        public readonly IServiceRepository _serviceRepository;
        public ServiceBLL() {
            _serviceRepository = new ServiceRepository();
        }

        public Service CreateService(Service service) {
            throw new NotImplementedException();
        }

        public List<Service> GetServices() {
            return _serviceRepository.GetServices();
        }
    }
}