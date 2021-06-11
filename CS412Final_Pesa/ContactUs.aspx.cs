using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa {
    public partial class ContactUs : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnSendInfo_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(name.Text) ||
                string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(phone.Text) ||
                string.IsNullOrWhiteSpace(comment.Text)) {
                errorPanel.Visible = true;
                lblErrors.Text = "Please ensure that all fields are filled.";
                return;
            }
                
            SendFeedback(name.Text, email.Text, phone.Text, comment.Text);
        }

        public void SendFeedback(string name, string email, string phone, string comment) {
            //send feedback code here
        }
    }
}