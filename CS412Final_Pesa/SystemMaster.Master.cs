using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa {
    public partial class SystemMaster : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            bool isUserLoggedIn = true;
            if (isUserLoggedIn == false)
                Response.Redirect("Login.aspx");
        }
    }
}