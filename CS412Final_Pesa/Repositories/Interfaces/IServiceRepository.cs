using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS412Final_Pesa.Repositories.Interfaces {
    public interface IServiceRepository {
        List<Service> GetServices();
        Service CreateService(Service service);
        List<OrderServices> GetOrderServices(List<long> orderIds);
        void AssociateOrderToServices(long orderId, List<long> serviceIds);
        bool DeleteOrderServices(long orderId);
    }
}
