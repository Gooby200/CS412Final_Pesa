using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS412Final_Pesa.BLL.Interfaces {
    public interface IUserBLL {
        User GetUser(string email, string password);
        User CreateUser(User user);
        bool UserExists(string email);
    }
}
