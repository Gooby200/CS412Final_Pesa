using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace CS412Final_Pesa.BLL {
    public class NotificationsBLL : INotificationsBLL {
        private readonly IError _error;
        public NotificationsBLL() {
            _error = new Error();
        }
        public async Task SendEmail(string to, string subject, string body, string replyTo = "") {
            //send feedback code here
            using (MailMessage message = new MailMessage()) {
                message.To.Add(to.Trim());
                message.From = new MailAddress(message.From.Address, "Order Through Me");
                message.Subject = subject;
                if (string.IsNullOrWhiteSpace(replyTo) == false) {
                    message.ReplyToList.Add(replyTo.Trim());
                }
                message.Body = body;
                message.IsBodyHtml = true;

                using (SmtpClient client = new SmtpClient()) {
                    try {
                        await client.SendMailAsync(message);
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
        }
    }
}