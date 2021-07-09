using CS412Final_Pesa.Models;
using System;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa.UserControls {
    public partial class OrderControl : System.Web.UI.UserControl {
        public Order Order {
            get {
                return (Order)ViewState["order"];
            }
            set {
                ViewState["order"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (Order != null) {
                litOrderNumber.Text = Order.Id.ToString();
                litCustomerName.Text = Order.CustomerName;
                litServiceDate.Text = Order.ServiceDate.ToString();
                lblTotal.Text = Order.Total.ToString("c");
                BindServiceRepeater();
            }
        }

        public void BindServiceRepeater() {
            ServiceRepeater.DataSource = Order.Services;
            ServiceRepeater.DataBind();
        }

        protected void ServiceRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                Service service = (Service)e.Item.DataItem;

                Label ServiceName = (Label)e.Item.FindControl("ServiceName");
                Label ServicePrice = (Label)e.Item.FindControl("ServicePrice");

                ServiceName.Text = service.Name;
                ServicePrice.Text = service.Price.ToString("c");
            }
        }
    }
}