using CustomerManagement_BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CMBL_UnitTest
{
    [TestClass]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void RetrieveValidate()
        {
            //arrange
            var orderRepository = new OrderRepository();
            var expected = new Order(10);
            expected.OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0));

            //act
            var result = orderRepository.Retrieve(10);

            //assert
            Assert.AreEqual(expected.OrderId, result.OrderId);
            Assert.AreEqual(expected.OrderDate, result.OrderDate);
        }

        [TestMethod]
        public void SaveChangesValid()
        {
            //arrange
            var orderRepository = new OrderRepository();
            var order = new Order(10)
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0)),    
                HasChanges = true
            };

            //act
            var result = orderRepository.Save(order);
            var expected = true;

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SaveChangesInvalid()
        {
            //arrange
            var orderRepository = new OrderRepository();
            var order = new Order(10)
            {
                OrderDate = null,
                HasChanges = true
            };

            //act
            var result = orderRepository.Save(order);
            var expected = false;

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
