using CS412Final_Pesa.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CS412Final_PesaTests.Helpers {
    [TestClass]
    public class MyClassTests {
        public MyClass myClass;

        [TestInitialize]
        public void Initialize() {
            myClass = new MyClass();
        }

        [TestMethod]
        public void MyOwnAddition_AddsTwo_ReturnsTrue() {
            // Arrange
            int x = 2;
            int y = 1;

            // Act
            var result = myClass.MyOwnAddition(x, y);

            // Assert
            Assert.IsTrue(result == 5);
        }
    }
}
