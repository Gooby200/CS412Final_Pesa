using CS412Final_Pesa.BLL;
using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Models;
using CS412Final_Pesa.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CS412Final_Pesa.Tests.BLL {
    [TestClass]
    public class OrderBLLTests {
        private IOrderBLL _orderBLL;
        private Mock<IOrderRepository> _orderRepositoryMock;
        private Mock<IServiceRepository> _serviceRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;

        [TestInitialize]
        public void TestInitialize() {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _orderBLL = new OrderBLL(_orderRepositoryMock.Object, _serviceRepositoryMock.Object, _userRepositoryMock.Object);
        }

        [TestMethod]
        public void GetOrder_TotalCorrect_ReturnsOrder() {
            //arrange
            Order order = new Order() {
                Id = 1,
                OrderedById = 1
            };

            List<OrderServices> orderServices = new List<OrderServices>() {
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 1,
                        Price = 6
                    }
                },
                new OrderServices() {
                    OrderId = 1,
                    Service = new Service() {
                        Id = 1,
                        Price = 4
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

            //act
            Order ret = _orderBLL.GetOrder(1);

            //assert
            Assert.IsNotNull(ret);
            Assert.IsTrue(ret.Total == 10M);
        }
    }
}
