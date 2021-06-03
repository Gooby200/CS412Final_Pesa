using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa {
    public partial class LoginPage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            List<string> errors = new List<string>();
            errorPanel.Visible = false;

            if (string.IsNullOrWhiteSpace(email.Text)) {
                errors.Add("You must provide an email.");
            }

            if (string.IsNullOrWhiteSpace(pass.Text)) {
                errors.Add("You must provide a password.");
            }

            //if we have no errors so far, try to login
            if (errors.Count == 0) {
                //TODO - Try to select the email address and password from the database
                //  and return the user's row with information. Have our data layer
                //  do the data access and then do the mapping in the data layer as well.
                //  we will want to access the data layer through the repository class

                bool matchedInDatabase = false;
                if (email.Text.ToLower() == "rgpesa1@neiu.edu" && pass.Text == "test") {
                    matchedInDatabase = true;
                }

                if (matchedInDatabase) {
                    User user = new User() {
                        First = "Gaston",
                        Last = "Pesa",
                        Email = "rgpesa1@neiu.edu",
                        Password = "test"
                    };

                    //TODO - Redirect the user to the login page or the employee side of the site
                    Response.Redirect("Dashboard.aspx");
                } else {
                    errors.Add("User does not exist. Please make sure you entered the correct email/password.");
                }
            }

            //if we received an error, show the user the errors
            if (errors.Count > 0) {
                errorPanel.Visible = true;
                lblErrors.Text = string.Join("<br />", errors);
                return;
            }
        }
    }
}