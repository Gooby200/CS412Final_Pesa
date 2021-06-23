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
    public static class OrderDAL {
        private readonly static IError _error = new Error();
        public static List<Order> GetOrders(long userId = -1) {
            List<Order> orders = new List<Order>();
            string sql = "SELECT * FROM Orders";
            if (userId > -1) {
                sql += " WHERE OrderedBy=@UserId";
            }
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) {
                    try {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.HasRows) {
                                while (reader.Read()) {
                                    orders.Add(new Order() {
                                        CustomerName = reader.GetString("CustomerName"),
                                        Id = reader.GetInt64("Id"),
                                        PaidAmount = reader.GetDecimal("PaidAmount"),
                                        ServiceDate = reader.GetDateTime("ServiceDate"),
                                        OrderedById = reader.GetInt64("OrderedBy")
                                    });
                                }
                            }
                        }
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
            return orders;
        }

        public static List<long> GetOrderedByUserIds(List<long> orderIds) {
            List<long> userIds = new List<long>();
            string sql = "SELECT OrderedBy FROM Orders WHERE ID IN (#OrderIds)";
            sql = sql.Replace("#OrderIds", string.Join(", ", orderIds));
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) {
                    try {
                        cmd.Connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.HasRows) {
                                while (reader.Read()) {
                                    userIds.Add(reader.GetInt64("OrderedBy"));
                                }
                            }
                        }
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
            return userIds;
        }

        public static long GetOrderCount() {
            long count = 0;
            string sql = "SELECT COUNT(*) FROM Orders";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) {
                    try {
                        cmd.Connection.Open();
                        count = (long)cmd.ExecuteScalar();
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
            return count;
        }

        public static List<Order> GetCompletedOrders() {
            List<Order> orders = new List<Order>();
            string sql = "SELECT * FROM Orders WHERE ServiceDate < NOW()";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) {
                    try {
                        cmd.Connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader()) {
                            if (reader.HasRows) {
                                while (reader.Read()) {
                                    orders.Add(new Order() {
                                        CustomerName = reader.GetString("CustomerName"),
                                        Id = reader.GetInt64("Id"),
                                        PaidAmount = reader.GetDecimal("PaidAmount"),
                                        ServiceDate = reader.GetDateTime("ServiceDate"),
                                        OrderedById = reader.GetInt64("OrderedBy")
                                    });
                                }
                            }
                        }
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
            return orders;
        }

        public static bool DeleteOrder(long orderId) {
            string sql = @"DELETE FROM Orders WHERE Id=@OrderId";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) {
                    try {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.ExecuteNonQuery();
                    } catch (Exception ex) {
                        _error.Log(ex);
                        return false;
                    }
                }
            }
            return true;
        }

        public static Order CreateOrder(Order order) {
            string sql = @"INSERT INTO Orders (CustomerName, ServiceDate, PaidAmount, OrderedBy) VALUES (@CustomerName, @ServiceDate, @PaidAmount, @OrderedBy);
                            SELECT LAST_INSERT_ID();";
            using (MySqlConnection conn = new MySqlConnection(WebConfigurationManager.AppSettings["connString"])) {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) {
                    try {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                        cmd.Parameters.AddWithValue("@ServiceDate", order.ServiceDate);
                        cmd.Parameters.AddWithValue("@PaidAmount", order.PaidAmount);
                        cmd.Parameters.AddWithValue("@OrderedBy", order.OrderedBy.Id);

                        string o = cmd.ExecuteScalar().ToString();
                        long id = 0;
                        long.TryParse(o, out id);
                        order.Id = id;
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
            return order;
        }
    }
}