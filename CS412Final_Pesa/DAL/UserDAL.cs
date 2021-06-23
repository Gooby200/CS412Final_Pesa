using CS412Final_Pesa.Helpers;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web.Configuration;

namespace CS412Final_Pesa.DAL {
    public static class UserDAL {
        private readonly static IError _error = new Error();
        public static User GetUser(string email, string password) {
            User user = null;
            string sql = @"SELECT a.*, b.Address1, b.Address2, b.City, b.State, b.Zip  
                            FROM Users a
                            INNER JOIN Addresses b ON a.AddressId=b.Id
                            WHERE Email=@Email AND Password=@Password";
            using (MySqlConnection connection = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
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
                                        Email = reader.GetNullString("Email"),
                                        First = reader.GetNullString("First"),
                                        Last = reader.GetNullString("Last"),
                                        Password = reader.GetNullString("Password"),
                                        Phone = reader.GetNullString("Phone"),
                                        Address = new Address() {
                                            Id = reader.GetInt64("AddressId"),
                                            Address1 = reader.GetNullString("Address1"),
                                            Address2 = reader.GetNullString("Address2"),
                                            City = reader.GetNullString("City"),
                                            State = reader.GetNullString("State"),
                                            Zip = reader.GetNullString("Zip"),
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

        public static List<User> GetUsers(List<long> userIds) {
            List<User> users = new List<User>();
            string sql = @"SELECT a.*, b.Address1, b.Address2, b.City, b.State, b.Zip  
                            FROM Users a
                            INNER JOIN Addresses b ON a.AddressId=b.Id
                            WHERE a.Id IN (#UserIds)";
            sql = sql.Replace("#UserIds", string.Join(", ", userIds));
            using (MySqlConnection connection = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection)) {
                    try {
                        cmd.Connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.HasRows) {
                                while (reader.Read()) {
                                    users.Add(new User() {
                                        Id = reader.GetInt64("Id"),
                                        Email = reader.GetNullString("Email"),
                                        First = reader.GetNullString("First"),
                                        Last = reader.GetNullString("Last"),
                                        Password = reader.GetNullString("Password"),
                                        Phone = reader.GetNullString("Phone"),
                                        Address = new Address() {
                                            Id = reader.GetInt64("AddressId"),
                                            Address1 = reader.GetNullString("Address1"),
                                            Address2 = reader.GetNullString("Address2"),
                                            City = reader.GetNullString("City"),
                                            State = reader.GetNullString("State"),
                                            Zip = reader.GetNullString("Zip"),
                                        }
                                    });
                                }
                            }
                        }
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
            return users;
        }

        public static bool DoesUserExistByEmail(string email) {
            bool ret = true;
            string sql = @"SELECT * FROM Users WHERE Email=@Email";
            using (MySqlConnection connection = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection)) {
                    try {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@Email", email);
                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            ret = reader.HasRows;
                        }
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
            return ret;
        }

        public static Address CreateAddress(Address address) {
            string sql = @"INSERT INTO Addresses (Address1, Address2, City, State, Zip) 
                            VALUES
                            (@Address1, @Address2, @City, @State, @Zip);
                            SELECT LAST_INSERT_ID();";
            using (MySqlConnection connection = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection)) {
                    try {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@Address1", address.Address1);
                        cmd.Parameters.AddWithValue("@Address2", address.Address2);
                        cmd.Parameters.AddWithValue("@City", address.City);
                        cmd.Parameters.AddWithValue("@State", address.State);
                        cmd.Parameters.AddWithValue("@Zip", address.Zip);

                        string o = cmd.ExecuteScalar().ToString();
                        long id = 0;
                        long.TryParse(o, out id);
                        address.Id = id;
                    } catch (Exception ex) {
                        _error.Log(ex);
                        return null;
                    }
                }
            }
            return address; 
        }

        public static User CreateUser(User user) {
            string sql = @"INSERT INTO Users (First, Last, Email, Phone, Password, AddressId) 
                            VALUES
                            (@First, @Last, @Email, @Phone, @Password, @AddressId);
                            SELECT LAST_INSERT_ID();";
            using (MySqlConnection connection = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection)) {
                    try {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@First", user.First);
                        cmd.Parameters.AddWithValue("@Last", user.Last);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Phone", user.Phone);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        cmd.Parameters.AddWithValue("@AddressId", user.Address.Id);

                        string o = cmd.ExecuteScalar().ToString();
                        long id = 0;
                        long.TryParse(o, out id);
                        user.Id = id;
                    } catch (Exception ex) {
                        _error.Log(ex);
                        return null;
                    }
                }
            }
            return user;
        }
    }
}