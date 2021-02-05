using CustomerManagement_BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CMBL_UnitTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameValid()
        {
            //arrange
            var customer = new Customer { FirstName = "Sakura", LastName = "Kinomoto" };
            string expected = "Kinomoto, Sakura";

            //act
            var result = customer.FullName;

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //arrange
            var customer = new Customer { FirstName = "Sakura" };
            string expected = "Sakura";

            //act
            var result = customer.FullName;

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StaticCounterTest()
        {
            //arrange
            var customerA = new Customer { FirstName = "Sakura", LastName = "Kinomoto" };
            //a static member is referenced by the class name, cause doesn't belong to any instance
            Customer.CustomerCount++;

            var customerB = new Customer { FirstName = "Syaoran", LastName = "Li" };
            Customer.CustomerCount++;
            var customerC = new Customer { FirstName = "Tomoyo", LastName = "Daidouji" };
            Customer.CustomerCount++;

            int expected = 3;

            //act
            var result = Customer.CustomerCount;

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ValidateEmptyLastName()
        {
            //arrange
            var customer = new Customer();
            var expected = false;

            //act
            var result = customer.Validate();

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
