using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS412Final_Pesa.BLL.Interfaces {
    public interface INotificationsBLL {
        Task SendEmail(string to, string subject, string body, string replyTo = "");
    }
}
