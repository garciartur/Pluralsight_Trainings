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
    }
}
