using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.BLL {
    public class UserBLL : IUserBLL {
        private readonly IUserRepository _userRepository;
        public UserBLL() {
            _userRepository = new UserRepository();
        }

        public User CreateUser(User user) {
            return _userRepository.CreateUser(user);
        }

        public User GetUser(string email, string password) {
            return _userRepository.GetUser(email, password);
        }
    }
}