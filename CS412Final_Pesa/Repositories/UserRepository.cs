using CS412Final_Pesa.DAL;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.Repositories {
    public class UserRepository : IUserRepository {
        public User CreateUser(User user) {
            return UserDAL.CreateUser(user);
        }

        public User GetUser(string email, string password) {
            return UserDAL.GetUser(email, password);
        }
    }
}