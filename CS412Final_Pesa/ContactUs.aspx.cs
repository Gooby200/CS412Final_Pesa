using CS412Final_Pesa.BLL;
using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Net.Mail;

namespace CS412Final_Pesa {
    public partial class ContactUs : System.Web.UI.Page {
        private readonly static IError _error = new Error();
        private readonly INotificationsBLL _notifications = new NotificationsBLL();
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

        public void SendFeedback(string userName, string userEmail, string phone, string comment) {
            string to = userEmail;
            string subject = "OTM Feedback";
            string replyTo = to;
            string body = $@"
                            <p>User Email: {userEmail}</p>
                            <p>User Name: {userName}</p>
                            <p>User Phone: {phone}</p>
                            <p>User Comment:<br>
                            {comment}
                            </p>
                            ";

            _notifications.SendEmail(to, subject, body, replyTo);
        }
    }
}