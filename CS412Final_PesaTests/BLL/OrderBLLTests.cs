using CS412Final_Pesa.BLL;
using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS412Final_PesaTests.BLL {
    [TestClass]
    public class OrderBLLTests {
        private IOrderBLL _orderBLL;
        private Mock<IOrderRepository> _orderRepositoryMock;
        private Mock<IServiceRepository> _serviceRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;

        [TestInitialize]
        public void Initialize() {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _orderBLL = new OrderBLL(_orderRepositoryMock.Object, _serviceRepositoryMock.Object, _userRepositoryMock.Object);
        }

        [TestMethod]
        public void CreateOrder_ReturnsOrder() {
            // arrange
            List<long> serviceIds = new List<long> { 1, 2, 3 };

            Order mockOrder = new Order() {
                Id = 1,
                CustomerName = "Gaston Pesa",
                OrderedById = 1,
                PaidAmount = 0,
                ServiceDate = DateTime.Now
            };

            List<OrderServices> orderServices = new List<OrderServices>() {
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 1,
                        Name = "Service 1",
                        Price = 3
                    }
                },
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 2,
                        Name = "Service 2",
                        Price = 5
                    }
                },
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Name = "Service 3",
                        Id = 3
                    }
                }
            };

            List<User> users = new List<User>() {
                new User() {
                    Id = 1,
                    First = "Gaston",
                    Last = "Pesa"
                }
            };

            _orderRepositoryMock.Setup(x => x.CreateOrder(It.IsAny<Order>())).Returns(mockOrder);
            _serviceRepositoryMock.Setup(x => x.AssociateOrderToServices(It.IsAny<long>(), It.IsAny<List<long>>())).Verifiable();
            _serviceRepositoryMock.Setup(x => x.GetOrderServices(It.IsAny<List<long>>())).Returns(orderServices);
            _userRepositoryMock.Setup(x => x.GetUsers(It.IsAny<List<long>>())).Returns(users);

            //act
            var order = _orderBLL.CreateOrder(mockOrder, serviceIds);

            //assert
            Assert.IsNotNull(order);
            Assert.IsTrue(order.OrderedBy.Id == users[0].Id);
            Assert.IsTrue(order.Services.Count == 3);
            Assert.IsTrue(order.Total == 8);
            Assert.IsTrue(order.Services[0].Name == "Service 1");
        }

        [TestMethod]
        public void GetCompletedOrders_GetsAllCompletedOrders_ReturnsOrders() {
            List<Order> completedOrders = new List<Order>() {
                new Order() {
                    Id = 1,
                    CustomerName = "Gaston Pesa",
                    OrderedById = 1,
                },
                new Order() {
                    Id = 2,
                    CustomerName = "John Smith",
                    OrderedById = 2
                }
            };

            List<OrderServices> orderServices = new List<OrderServices>() {
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 1,
                        Price = 3
                    }
                },
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 2,
                        Price = 5
                    }
                },
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 3
                    }
                },
                new OrderServices() {
                    OrderId = 2,
                    Service = new Service() {
                        Id = 3
                    }
                }
            };

            List<User> users = new List<User>() {
                new User() {
                    Id = 1,
                    First = "Gaston",
                    Last = "Pesa"
                }
            };

            _orderRepositoryMock.Setup(x => x.GetCompletedOrders()).Returns(completedOrders);
            _serviceRepositoryMock.Setup(x => x.GetOrderServices(It.IsAny<List<long>>())).Returns(orderServices);
            _userRepositoryMock.Setup(x => x.GetUsers(It.IsAny<List<long>>())).Returns(users);

            List<Order> ret = _orderBLL.GetCompletedOrders();

            //assert
            Assert.IsNotNull(ret);
            Assert.IsTrue(ret.Count == 2);
            Assert.IsTrue(ret[0].OrderedBy.Id == users[0].Id);
            Assert.IsTrue(ret[0].Services.Count == 3);
            Assert.IsTrue(ret[0].Total == 8);
        }

        [TestMethod]
        public void GetOrder_ByOrderId_ReturnsOrder() {
            Order order = new Order() {
                Id = 1,
                CustomerName = "John Smith",
                OrderedById = 1
            };

            List<OrderServices> orderServices = new List<OrderServices>() {
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 1,
                        Price = 3
                    }
                },
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 2,
                        Price = 5
                    }
                },
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 3
                    }
                },
                new OrderServices() {
                    OrderId = 2,
                    Service = new Service() {
                        Id = 3
                    }
                }
            };

            List<User> users = new List<User>() {
                new User() {
                    Id = 1,
                    First = "Gaston",
                    Last = "Pesa"
                }
            };

            _orderRepositoryMock.Setup(x => x.GetOrder(It.IsAny<long>())).Returns(order);
            _serviceRepositoryMock.Setup(x => x.GetOrderServices(It.IsAny<List<long>>())).Returns(orderServices);
            _userRepositoryMock.Setup(x => x.GetUsers(It.IsAny<List<long>>())).Returns(users);

            Order ret = _orderBLL.GetOrder(1);

            Assert.IsNotNull(ret);
            Assert.IsTrue(ret.OrderedBy.Id == users[0].Id);
            Assert.IsTrue(ret.Services.Count == 3);
            Assert.IsTrue(ret.Total == 8);
        }

        [TestMethod]
        public void GetOrder_OrderIdDoesntExist_ReturnsNull() {
            Order order = null;

            List<OrderServices> orderServices = new List<OrderServices>() {
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 1,
                        Price = 3
                    }
                },
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 2,
                        Price = 5
                    }
                },
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 3
                    }
                },
                new OrderServices() {
                    OrderId = 2,
                    Service = new Service() {
                        Id = 3
                    }
                }
            };

            List<User> users = new List<User>() {
                new User() {
                    Id = 1,
                    First = "Gaston",
                    Last = "Pesa"
                }
            };

            _orderRepositoryMock.Setup(x => x.GetOrder(It.IsAny<long>())).Returns(order);

            Order ret = _orderBLL.GetOrder(2);

            Assert.IsNull(ret);
        }

        [TestMethod]
        public void GetMoneyCollected_AllOrders_ReturnsMoney() {
            List<Order> orders = new List<Order>() {
                new Order() {
                    Id = 1,
                    PaidAmount = 3,
                    ServiceDate = DateTime.Now.AddDays(-1)
                },
                new Order() {
                    Id = 2,
                    PaidAmount = 4,
                    ServiceDate = DateTime.Now.AddDays(-2)
                },
                new Order() {
                    Id = 3,
                    PaidAmount = 3,
                    ServiceDate = DateTime.Now.AddDays(1)
                },
                new Order() {
                    Id = 4,
                    PaidAmount = 3,
                    ServiceDate = DateTime.Now.AddDays(2)
                },
            };

            _orderRepositoryMock.Setup(x => x.GetOrders(It.IsAny<long>())).Returns(orders);

            var ret = _orderBLL.GetMoneyCollected();

            Assert.IsTrue(ret == 7M);
        }

        [TestMethod]
        public void GetOrderCount_CompletedOrders_ReturnsSameNumber() {
            _orderRepositoryMock.Setup(x => x.GetOrderCount()).Returns(4);
            var count = _orderBLL.GetOrderCount();
            Assert.IsTrue(count == 4);
        }

        [TestMethod]
        public void GetOrders_ByUser_ReturnsOrders() {
            List<Order> orders = new List<Order>() {
                new Order() {
                    Id = 1,
                    OrderedById = 2,
                    ServiceDate = DateTime.Now
                },
                new Order() {
                    Id = 2,
                    OrderedById = 2,
                    ServiceDate = DateTime.Now
                },
                new Order() {
                    Id = 3,
                    OrderedById = 2,
                    ServiceDate = DateTime.Now
                }
            };

            List<OrderServices> orderServices = new List<OrderServices>();

            List<User> users = new List<User>() {
                new User() {
                    Id = 1
                },
                new User() {
                    Id = 2
                },
                new User() {
                    Id = 3
                }
            };

            _orderRepositoryMock.Setup(x => x.GetOrders(It.IsAny<long>())).Returns(orders);
            _serviceRepositoryMock.Setup(x => x.GetOrderServices(It.IsAny<List<long>>())).Returns(orderServices);
            _userRepositoryMock.Setup(x => x.GetUsers(It.IsAny<List<long>>())).Returns(users);

            var ret = _orderBLL.GetOrders(2);

            Assert.IsNotNull(ret);
            Assert.IsTrue(ret.All(x => x.OrderedById == 2));
        }

        [TestMethod]
        public void GetOrders_AllOrders_ReturnsOrders() {
            List<Order> orders = new List<Order>() {
                new Order() {
                    Id = 1,
                    OrderedById = 2,
                    ServiceDate = DateTime.Now
                },
                new Order() {
                    Id = 2,
                    OrderedById = 2,
                    ServiceDate = DateTime.Now
                },
                new Order() {
                    Id = 3,
                    OrderedById = 3,
                    ServiceDate = DateTime.Now
                }
            };

            List<OrderServices> orderServices = new List<OrderServices>();

            List<User> users = new List<User>();

            _orderRepositoryMock.Setup(x => x.GetOrders(It.IsAny<long>())).Returns(orders);
            _serviceRepositoryMock.Setup(x => x.GetOrderServices(It.IsAny<List<long>>())).Returns(orderServices);
            _userRepositoryMock.Setup(x => x.GetUsers(It.IsAny<List<long>>())).Returns(users);

            var ret = _orderBLL.GetOrders();

            Assert.IsNotNull(ret);
            Assert.IsTrue(ret.Count == 3);
        }

        [TestMethod]
        public void GetOrders_AssociatesUserAndServices_ReturnsOrders() {
            List<Order> orders = new List<Order>() {
                new Order() {
                    Id = 1,
                    OrderedById = 1
                },
                new Order() {
                    Id = 2,
                    OrderedById = 2
                },
                new Order() {
                    Id = 3,
                    OrderedById = 2
                }
            };

            List<OrderServices> orderServices = new List<OrderServices>() {
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 1
                    }
                },
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 2
                    }
                },
                new OrderServices() {
                    OrderId = 2,
                    Service = new Service() {
                        Id = 3
                    }
                }
            };

            List<User> users = new List<User>() {
                new User() {
                    Id = 1
                },
                new User() {
                    Id = 2
                }
            };

            _orderRepositoryMock.Setup(x => x.GetOrders(It.IsAny<long>())).Returns(orders);
            _serviceRepositoryMock.Setup(x => x.GetOrderServices(It.IsAny<List<long>>())).Returns(orderServices);
            _userRepositoryMock.Setup(x => x.GetUsers(It.IsAny<List<long>>())).Returns(users);

            var ret = _orderBLL.GetOrders();

            Assert.IsNotNull(ret);
            Assert.IsTrue(ret.Count == 3);
            Assert.IsTrue(ret.All(x => x.OrderedById == x.OrderedBy.Id));
            Assert.IsTrue(ret.Where(x => x.Id == 1).Select(x => x.Services).ToList()[0].Count() == 2);
            Assert.IsTrue(ret.Where(x => x.Id == 2).Select(x => x.Services).ToList()[0].Count() == 1);
            Assert.IsTrue(ret.Where(x => x.Id == 3).Select(x => x.Services).ToList()[0].Count() == 0);
        }

        [TestMethod]
        public void GetOrder_TotalCorrect_ReturnsOrders() {
            Order order = new Order() {
                Id = 1,
                OrderedById = 1
            };

            List<OrderServices> orderServices = new List<OrderServices>() {
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 1,
                        Price = 4
                    }
                },
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 2,
                        Price = 6
                    }
                }
            };

            List<User> users = new List<User>() {
                new User() {
                    Id = 1
                },
                new User() {
                    Id = 2
                }
            };

            _orderRepositoryMock.Setup(x => x.GetOrder(It.IsAny<long>())).Returns(order);
            _serviceRepositoryMock.Setup(x => x.GetOrderServices(It.IsAny<List<long>>())).Returns(orderServices);
            _userRepositoryMock.Setup(x => x.GetUsers(It.IsAny<List<long>>())).Returns(users);

            var ret = _orderBLL.GetOrder(1);

            Assert.IsNotNull(ret);
            Assert.IsTrue(ret.Total == 10M);
        }

        [TestMethod]
        public void DeleteOrder_OrderDeleted_ReturnsBoolean() {
            _serviceRepositoryMock.Setup(x => x.DeleteOrderServices(It.IsAny<long>())).Returns(true);
            _orderRepositoryMock.Setup(x => x.DeleteOrder(It.IsAny<long>())).Returns(true);

            var ret = _orderBLL.DeleteOrder(It.IsAny<long>());

            Assert.IsTrue(ret);
        }

        [TestMethod]
        public void DeleteOrder_OrderNotDeletedExists_ReturnsBoolean() {
            _serviceRepositoryMock.Setup(x => x.DeleteOrderServices(It.IsAny<long>())).Returns(true);
            _orderRepositoryMock.Setup(x => x.DeleteOrder(It.IsAny<long>())).Returns(false);

            var ret = _orderBLL.DeleteOrder(It.IsAny<long>());

            Assert.IsFalse(ret);
        }

        [TestMethod]
        public void DeleteOrder_ServicesNotDeleted_ReturnsBoolean() {
            _serviceRepositoryMock.Setup(x => x.DeleteOrderServices(It.IsAny<long>())).Returns(false);
            _orderRepositoryMock.Setup(x => x.DeleteOrder(It.IsAny<long>())).Returns(true);

            var ret = _orderBLL.DeleteOrder(It.IsAny<long>());

            Assert.IsFalse(ret);
        }

        [TestMethod]
        public void ModifyOrder_ReturnsOrder() {
            //not yet implemented
        }

        [TestMethod]
        public void GetOrdersByCustomerName_ReturnsOrders() {
            List<Order> orders = new List<Order>() {
                new Order() {
                    Id = 1,
                    CustomerName = "Tester Man"
                },
                new Order() {
                    Id = 3,
                    CustomerName = "John Test"
                },
                new Order() {
                    Id = 4,
                    CustomerName = "Tester Tester"
                }
            };

            List<OrderServices> ordersServices = new List<OrderServices>();
            List<User> users = new List<User>();

            _orderRepositoryMock.Setup(x => x.GetOrdersByCustomerName(It.IsAny<string>())).Returns(orders);
            _serviceRepositoryMock.Setup(x => x.GetOrderServices(It.IsAny<List<long>>())).Returns(ordersServices);
            _userRepositoryMock.Setup(x => x.GetUsers(It.IsAny<List<long>>())).Returns(users);

            var ret = _orderBLL.GetOrdersByCustomerName(It.IsAny<string>());

            Assert.IsNotNull(ret);
        }
    }
}
