using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.DAL {
    public static class UserDAL {
        private static List<User> _users = new List<User>() {
            new User() {
                Id = 1,
                First = "Gaston",
                Last = "Pesa",
                Email = "rgpesa1@neiu.edu",
                Password = "test"
            }
        };
        public static User GetUser(string email, string password) {
            //this will go into the database and search for and return a user
            //with this information

            return _users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public static User CreateUser(User user) {
            //get the latest id from the users
            User lastUser = _users.LastOrDefault();
            user.Id = lastUser.Id + 1;
            _users.Add(user);

            return user;
        }
    }
}