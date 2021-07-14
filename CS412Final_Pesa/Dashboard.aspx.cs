using CS412Final_Pesa.BLL;
using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa {
    public partial class DashboardPage : System.Web.UI.Page {
        private readonly IOrderBLL _orderBLL;

        public DashboardPage(IOrderBLL orderBLL) {
            _orderBLL = orderBLL;
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack == false) {
                User user = (User)Session["user"];

                ViewState["orders"] = _orderBLL.GetOrders();
                ViewState["myOrders"] = _orderBLL.GetOrders(user.Id);

                BindAllGrids();
            }
        }

        private void SetPageData() {
            User user = (User)Session["user"];
            litOrderCount.Text = _orderBLL.GetOrderCount().ToString();
            litMoneyCollected.Text = _orderBLL.GetMoneyCollected().ToString();
            litOrdersCompleted.Text = _orderBLL.GetCompletedOrders().Count().ToString();
            loggedInUserName.Text = user?.First + " " + user?.Last;
        }

        private void BindOrderDetailsGrid() {
            gridOrderDetails.DataSource = ViewState["orders"];
            gridOrderDetails.DataBind();
        }

        private void BindMyOrdersGrid() {
            MyOrdersGrid.DataSource = ViewState["myOrders"];
            MyOrdersGrid.DataBind();
        }

        protected void gridOrderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gridOrderDetails.PageIndex = e.NewPageIndex;
            BindOrderDetailsGrid();
        }

        protected void gridOrderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            GridViewRow row = gridOrderDetails.Rows[e.RowIndex];

            HiddenField hdnId = (HiddenField)row.FindControl("hdnId");
            long Id = 0;
            if (long.TryParse(hdnId.Value, out Id)) {
                Order order = ((List<Order>)ViewState["orders"]).FirstOrDefault(x => x.Id == Id);
                if (order != null) {
                    User user = (User)Session["user"];

                    _orderBLL.DeleteOrder(order.Id);
                    ViewState["orders"] = _orderBLL.GetOrders();
                    ViewState["myOrders"] = _orderBLL.GetOrders(user.Id);

                    BindAllGrids();
                }
            }
        }

        protected void gridOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Order order = (Order)e.Row.DataItem;

                Label customerName = (Label)e.Row.FindControl("lblCustomerName");
                //customerName.Text = order.Customer.First + " " + order.Customer.Last;
                customerName.Text = order.CustomerName;

                Label services = (Label)e.Row.FindControl("lblServices");
                services.Text = string.Join(", ", order.Services.Select(x => x.Name));

                Label orderPrice = (Label)e.Row.FindControl("lblOrderPrice");
                orderPrice.Text = $"${order.Total}";

                Label serviceDate = (Label)e.Row.FindControl("lblServiceDate");
                serviceDate.Text = order.ServiceDate.ToShortDateString();

                HiddenField id = (HiddenField)e.Row.FindControl("hdnId");
                id.Value = order.Id.ToString();

                User user = (User)Session["user"];
                if (order.OrderedBy.Id != user.Id) {
                    LinkButton deleteCmdField = (LinkButton)e.Row.Cells[5].Controls[0];
                    deleteCmdField.Visible = false;
                }
            }
        }

        protected void MyOrdersGrid_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Order order = (Order)e.Row.DataItem;

                Label customerName = (Label)e.Row.FindControl("lblCustomerName");
                //customerName.Text = order.Customer.First + " " + order.Customer.Last;
                customerName.Text = order.CustomerName;

                Label services = (Label)e.Row.FindControl("lblServices");
                services.Text = string.Join(", ", order.Services.Select(x => x.Name));

                Label orderPrice = (Label)e.Row.FindControl("lblOrderPrice");
                orderPrice.Text = $"${order.Total}";

                Label serviceDate = (Label)e.Row.FindControl("lblServiceDate");
                serviceDate.Text = order.ServiceDate.ToShortDateString();

                HiddenField id = (HiddenField)e.Row.FindControl("hdnId");
                id.Value = order.Id.ToString();
            }
        }

        protected void MyOrdersGrid_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            MyOrdersGrid.PageIndex = e.NewPageIndex;
            BindMyOrdersGrid();
        }

        private void BindAllGrids() {
            SetPageData();
            BindOrderDetailsGrid();
            BindMyOrdersGrid();
            BindOrderControlRepeater();
        }

        private void BindOrderControlRepeater() {
            OrderControlRepeater.DataSource = ViewState["myOrders"];
            OrderControlRepeater.DataBind();
        }

        protected void OrderControlRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                Order order = (Order)e.Item.DataItem;
                OrderControl oc = (OrderControl)e.Item.FindControl("OrderControl");
                oc.Order = order;
            }
        }
    }
}