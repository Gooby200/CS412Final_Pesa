using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.DAL {
    public static class UserDAL {
        private readonly static IError _error = new Error();
        public static User GetUser(string email, string password) {
            User user = null;
            string sql = @"SELECT a.*, b.Address1, b.Address2, b.City, b.State, b.Zip  
                            FROM Users a
                            INNER JOIN Addresses b ON a.AddressId=b.Id
                            WHERE Email=@Email AND Password=@Password";
            using (MySqlConnection connection = new MySqlConnection()) {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection)) {
                    try {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.HasRows) {
                                if (reader.Read()) {
                                    user = new User() {
                                        Id = reader.GetInt64("Id"),
                                        Email = reader.GetString("Email"),
                                        First = reader.GetString("First"),
                                        Last = reader.GetString("Last"),
                                        Password = reader.GetString("Password"),
                                        Phone = reader.GetString("Phone"),
                                        Address = new Address() {
                                            Id = reader.GetInt64("AddressId"),
                                            Address1 = reader.GetString("Address1"),
                                            Address2 = reader.GetString("Address2"),
                                            City = reader.GetString("City"),
                                            State = reader.GetString("State"),
                                            Zip = reader.GetString("Zip"),
                                        }
                                    };
                                }
                            }
                        }
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
            return user;
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