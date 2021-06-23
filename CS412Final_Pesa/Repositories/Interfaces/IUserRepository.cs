using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS412Final_Pesa.Repositories.Interfaces {
    public interface IUserRepository {
        User GetUser(string email, string password);
        User CreateUser(User user);
        Address CreateAddress(Address address);
        bool DoesUserExistByEmail(string email);
        List<User> GetUsers(List<long> userIds);
    }
}
