using CS412Final_Pesa.BLL;
using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa {
    public partial class SignUpPage : System.Web.UI.Page {
        private readonly IUserBLL _userBLL = new UserBLL();
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnSignup_Click(object sender, EventArgs e) {
            List<string> errors = new List<string>();
            errorPanel.Visible = false;

            if (string.IsNullOrWhiteSpace(first.Text)) {
                errors.Add("You must provide a first name.");
            }
            
            if (string.IsNullOrWhiteSpace(last.Text)) {
                errors.Add("You must provide a last name.");
            }

            if (string.IsNullOrWhiteSpace(email.Text)) {
                errors.Add("You must provide an email.");
            }

            if (string.IsNullOrWhiteSpace(pass.Text)) {
                errors.Add("You must provide a password.");
            }

            if (vpass.Text != pass.Text) {
                errors.Add("Both passwords must match.");
            }

            if (errors.Count > 0) {
                errorPanel.Visible = true;
                lblErrors.Text = string.Join("<br />", errors);
                return;
            }

            //everything passed correctly, so lets create the user object
            User user = new User() {
                First = first.Text,
                Last = last.Text,
                Email = email.Text,
                Password = pass.Text
            };

            //TODO - add functionality to hit the database to create this user
            User newUser = _userBLL.CreateUser(user);

            Session["user"] = newUser;

            //TODO - Redirect the user to the login page or the employee side of the site
            Response.Redirect("Dashboard.aspx");
        }
    }
}