using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CS412Final_Pesa.DAL {
    public static class ServiceDAL {
        private readonly static IError _error = new Error();

        public static List<Service> GetServices() {
            List<Service> services = new List<Service>();
            string sql = "SELECT * FROM Services";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) {
                    try {
                        cmd.Connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.HasRows) {
                                while (reader.Read()) {
                                    services.Add(new Service() {
                                        Id = reader.GetInt64("Id"),
                                        Name = reader.GetString("Name"),
                                        Price = reader.GetDecimal("Price")
                                    });
                                }
                            }
                        }
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
            return services;
        }

        public static List<OrderServices> GetOrderServices(List<long> orderIds) {
            List<OrderServices> orderServices = new List<OrderServices>();

            string sql = @"SELECT a.*, b.OrderId
                            FROM Services a
                            INNER JOIN OrderServices b ON a.Id=b.ServiceId
                            WHERE b.OrderId IN (#ORDERIDS)
                            ";
            sql = sql.Replace("#ORDERIDS", string.Join(", ", orderIds));
            using (MySqlConnection connection = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection)) {
                    try {
                        cmd.Connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.HasRows) {
                                while (reader.Read()) {
                                    orderServices.Add(new OrderServices() {
                                        OrderId = reader.GetInt64("OrderId"),
                                        Service = new Service() {
                                            Id = reader.GetInt64("Id"),
                                            Name = reader.GetString("Name"),
                                            Price = reader.GetDecimal("Price")
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

            return orderServices;
        }

        public static Service CreateService(Service service) {
            string sql = @"INSERT INTO Services (Name, Price) VALUES (@Name, @Price);
                            SELECT LAST_INSERT_ID();";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) {
                    try {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@Name", service.Name);
                        cmd.Parameters.AddWithValue("@Price", service.Price);

                        string o = cmd.ExecuteScalar().ToString();
                        long id = 0;
                        long.TryParse(o, out id);
                        service.Id = id;
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
            return service;
        }

        public static bool DeleteOrderServices(long orderId) {
            string sql = @"DELETE FROM OrderServices WHERE OrderId=@OrderID";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) {
                    try {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@OrderID", orderId);
                        cmd.ExecuteNonQuery();
                    } catch (Exception ex) {
                        _error.Log(ex);
                        return false;
                    }
                }
            }
            return true;
        }

        public static void AssociateOrderToServices(long orderId, List<long> serviceIds) {
            string sql = @"INSERT INTO OrderServices (OrderId, ServiceId) VALUES #SERVICES";
            List<string> values = new List<string>();
            foreach (long serviceId in serviceIds) {
                values.Add($"({orderId}, {serviceId})");
            }
            sql = sql.Replace("#SERVICES", string.Join(", ", values));
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) {
                    try {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
        }
    }
}