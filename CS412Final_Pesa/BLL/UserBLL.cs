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
            //first, validate that we don't already have a user like this in our database
            if (_userRepository.DoesUserExistByEmail(user.Email) == false) {
                //first we want to create the address
                user.Address = _userRepository.CreateAddress(user.Address);
                if (user.Address != null) {
                    //then we want to create the user
                    return _userRepository.CreateUser(user);
                }
            }

            return null;
        }

        public User GetUser(string email, string password) {
            return _userRepository.GetUser(email, password);
        }
    }
}