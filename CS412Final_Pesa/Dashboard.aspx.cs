﻿using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa {
    public partial class DashboardPage : System.Web.UI.Page {
        private readonly List<Service> _services = new List<Service>() {
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

        private readonly List<Order> _orders = new List<Order>() {
            new Order() {
                Id = 1,
                Customer = new User() {
                    Id = 1,
                    First = "Gaston",
                    Last = "Pesa"
                },
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
                Customer = new User() {
                    Id = 1,
                    First = "Gaston",
                    Last = "Pesa"
                },
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
                Customer = new User() {
                    Id = 1,
                    First = "Gaston",
                    Last = "Pesa"
                },
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
        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack == false) {
                ViewState["orders"] = _orders;

                SetPageData();
                BindOrderDetailsGrid();
            }

            
        }

        private void SetPageData() {
            litOrderCount.Text = GetOrderCount().ToString();
            litMoneyCollected.Text = GetMoneyCollected().ToString();
            litOrdersCompleted.Text = GetOrdersCompleted().ToString();
        }

        private void BindOrderDetailsGrid() {
            gridOrderDetails.DataSource = ViewState["orders"];
            gridOrderDetails.DataBind();
        }

        private int GetOrderCount() {
            return ((List<Order>)ViewState["orders"]).Count();
        }

        private decimal GetMoneyCollected() {
            decimal moneyCollected = 0;
            foreach (Order order in ((List<Order>)ViewState["orders"]))
                if (order.ServiceDate < DateTime.Now)
                    moneyCollected += order.Total;

            return moneyCollected;
        }

        private int GetOrdersCompleted() {
            int ordersCompleted = 0;
            foreach (Order order in ((List<Order>)ViewState["orders"]))
                if (order.ServiceDate < DateTime.Now)
                    ordersCompleted++;

            return ordersCompleted;
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
                    ((List<Order>)ViewState["orders"]).Remove(order);

                    SetPageData();
                    BindOrderDetailsGrid();
                }
            }
        }

        protected void gridOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Order order = (Order)e.Row.DataItem;

                Label customerName = (Label)e.Row.FindControl("lblCustomerName");
                //customerName.Text = order.Customer.First + " " + order.Customer.Last;
                customerName.Text = $"{order.Customer.First} {order.Customer.Last}";

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
    }
}