using CS412Final_Pesa.DAL;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories.Interfaces;
using System.Collections.Generic;

namespace CS412Final_Pesa.Repositories {
    public class UserRepository : IUserRepository {
        public Address CreateAddress(Address address) {
            return UserDAL.CreateAddress(address);
        }

        public User CreateUser(User user) {
            return UserDAL.CreateUser(user);
        }

        public bool DoesUserExistByEmail(string email) {
            return UserDAL.DoesUserExistByEmail(email);
        }

        public User GetUser(string email, string password) {
            return UserDAL.GetUser(email, password);
        }

        public List<User> GetUsers(List<long> userIds) {
            return UserDAL.GetUsers(userIds);
        }
    }
}