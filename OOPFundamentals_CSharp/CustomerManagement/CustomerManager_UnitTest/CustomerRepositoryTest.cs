using CustomerManagement_BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CMBL_UnitTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveValidate()
        {
            //arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1);
            expected.EmailAdress = "sakurakinomoto@cardcaptors.com";
            expected.FirstName = "Sakura";
            expected.LastName = "Kinomoto";

            //act
            var result = customerRepository.Retrieve(1);

            //assert
            Assert.AreEqual(expected.CustomerID, result.CustomerID);
            Assert.AreEqual(expected.EmailAdress, result.EmailAdress);
            Assert.AreEqual(expected.FirstName, result.FirstName);
            Assert.AreEqual(expected.LastName, result.LastName);
            Assert.AreEqual(expected.FullName, result.FullName);
        }
    }
}
