using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa {
    public partial class SystemMaster : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            User loggedInUser = (User)Session["user"];
            if (loggedInUser == null)
                Response.Redirect("Login.aspx");
        }
    }
}