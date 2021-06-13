using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS412Final_Pesa.Repositories.Interfaces {
    interface IUserRepository {
        User GetUser(string email, string password);
        User CreateUser(User user);
    }
}
