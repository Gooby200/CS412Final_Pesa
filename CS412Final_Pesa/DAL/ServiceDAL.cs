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
        private static List<Service> _services = new List<Service>() {
            new Service() {
                Id = 1,
                Name = "Mowing",
                Price = 25.00M
            },
            new Service() {
                Id = 2,
                Name = "Cleanup",
                Price = 250.00M
            },
            new Service() {
                Id = 3,
                Name = "Tree Trimming",
                Price = 100.00M
            }
        };

        public static List<Service> GetServices() {
            return _services;
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
            //get the latest id from the services
            Service lastService = _services.LastOrDefault();
            service.Id = lastService.Id + 1;
            _services.Add(service);

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