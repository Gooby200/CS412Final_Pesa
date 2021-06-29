using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Net.Mail;

namespace CS412Final_Pesa {
    public partial class ContactUs : System.Web.UI.Page {
        private readonly static IError _error = new Error();
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
            //send feedback code here
            using (MailMessage message = new MailMessage()) {
                message.To.Add("rgpesa@yahoo.com");
                message.From = new MailAddress(message.From.Address, "Order Through Me");
                message.Subject = "OTM Feedback";
                message.ReplyToList.Add(userEmail.Trim());
                message.Body = $@"
                                <p>User Email: {userEmail}</p>
                                <p>User Name: {userName}</p>
                                <p>User Phone: {phone}</p>
                                <p>User Comment:<br>
                                {comment}
                                </p>
                                ";
                message.IsBodyHtml = true;

                using (SmtpClient client = new SmtpClient()) {
                    try {
                        client.Send(message);
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
        }
    }
}