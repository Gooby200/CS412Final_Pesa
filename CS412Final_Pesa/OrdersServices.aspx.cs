using CS412Final_Pesa.BLL;
using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa {
    public partial class OrdersServicesPage : System.Web.UI.Page {
        private readonly IOrderBLL _orderBLL = new OrderBLL();
        private readonly IServiceBLL _serviceBLL = new ServiceBLL();

        protected void Page_Load(object sender, EventArgs e) {
            // load all of the services into here
            foreach (Service s in _serviceBLL.GetServices()) {
                ListItem listItem = new ListItem($"{s.Name} - {s.Price}", s.Id.ToString());
                orderServiceList.Items.Add(listItem);
            }
        }

        protected void createOrder_Click(object sender, EventArgs e) {
            //get selected services
            List<long> serviceIds = new List<long>();
            foreach (ListItem service in orderServiceList.Items) {
                if (service.Selected) {
                    //grab the service only if it's selected in the checkbox list
                    serviceIds.Add(long.Parse(service.Value));
                }
            }

            //do validation here before we create our order to make sure everything is good
            Order o = new Order() {
                CustomerName = customerName.Text,
                ServiceDate = DateTime.Parse(serviceDate.Text)
            };
            _orderBLL.CreateOrder(o, serviceIds);
        }

        protected void createService_Click(object sender, EventArgs e) {
            decimal price = 0M;

            //try to convert the price to a decimal and if successful, lets create the service
            if (decimal.TryParse(servicePrice.Text, out price)) {
                Service service = new Service() {
                    Name = serviceName.Text,
                    Price = price
                };
                _serviceBLL.CreateService(service);
            }
        }
    }
}