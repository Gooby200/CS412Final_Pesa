using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa {
    public partial class OrdersServicesPage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            // load all of the services into here
            List<Service> services = GetServices();
            foreach (Service s in services) {
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
            CreateOrder(customerName.Text, DateTime.Parse(serviceDate.Text), serviceIds);
        }

        protected void createService_Click(object sender, EventArgs e) {
            decimal price = 0;

            //try to convert the price to a decimal and if successful, lets create the service
            if (decimal.TryParse(servicePrice.Text, out price)) {
                CreateService(serviceName.Text, price);
            }
        }

        private bool CreateOrder(string customerName, DateTime serviceDate, List<long> serviceIds) {
            List<Service> services = new List<Service>();
            foreach (long serviceId in serviceIds) {
                services.Add(new Service() { Id = serviceId });
            }

            Order o = new Order() {
                CustomerName = customerName,
                ServiceDate = serviceDate,
                Services = services
            };

            //hit up the database to save this order information
            return false;
        }

        private bool CreateService(string name, decimal price) {
            Service service = new Service() {
                Name = name,
                Price = price
            };

            return false;
        }

        private List<Service> GetServices() {
            // get a list of services here from the database at some point
            return new List<Service>();
        }
    }
}