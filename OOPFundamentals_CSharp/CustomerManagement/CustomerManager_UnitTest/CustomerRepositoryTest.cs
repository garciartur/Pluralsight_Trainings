using CustomerManagement_BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

        [TestMethod]
        public void RetrieveWithAddress()
        {
            //arrange
            Customer expected = new Customer(1)
            {
                EmailAdress = "sakurakinomoto@cardcaptors.com",
                FirstName = "Sakura",
                LastName = "Kinomoto",
                AddressList = new List<Address>()
                {
                    new Address()
                    {
                        AddressType = 1,
                        StreetLine1 = "Kinomoto's House",
                        City = "Tomoeda",
                        State = "Kanto",
                        Country = "Japan",
                        PostalCode = "1833-4"
                    },

                    new Address()
                    {
                        AddressType = 2,
                        StreetLine1 = "Tomoeda's Elementary School",
                        City = "Tomoeda",
                        State = "Kanto",
                        Country = "Japan",
                        PostalCode = "1455-4"
                    }
                }
            };

            //act
            var customerRepository = new CustomerRepository();
            var result = customerRepository.Retrieve(1);

            //assert
            Assert.AreEqual(expected.CustomerID, result.CustomerID);
            Assert.AreEqual(expected.EmailAdress, result.EmailAdress);
            Assert.AreEqual(expected.FirstName, result.FirstName);
            Assert.AreEqual(expected.LastName, result.LastName);
            Assert.AreEqual(expected.FullName, result.FullName);

            //asserting address data
            for (int i = 0; i < 1; i++)
            {
                Assert.AreEqual(expected.AddressList[i].AddressType, result.AddressList[i].AddressType);
                Assert.AreEqual(expected.AddressList[i].StreetLine1, result.AddressList[i].StreetLine1);
                Assert.AreEqual(expected.AddressList[i].City, result.AddressList[i].City);
                Assert.AreEqual(expected.AddressList[i].State, result.AddressList[i].State);
                Assert.AreEqual(expected.AddressList[i].Country, result.AddressList[i].Country);
                Assert.AreEqual(expected.AddressList[i].PostalCode, result.AddressList[i].PostalCode);
            }
        }

        [TestMethod]
        public void SaveChangesValid()
        {
            //arrange
            var customerRepository = new CustomerRepository();
            var customer = new Customer(1)
            {
                EmailAdress = "sakurakinomoto@cardcaptors.com",
                FirstName = "Sakura",
                LastName = "Kinomoto",
                HasChanges = true
            };

            //act
            var result = customerRepository.Save(customer);
            var expected = true;

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SaveChangesInvalid()
        {
            //arrange
            var customerRepository = new CustomerRepository();
            var customer = new Customer(1)
            {
                EmailAdress = null,
                FirstName = null,
                LastName = null,
                HasChanges = true
            };

            //act
            var result = customerRepository.Save(customer);
            var expected = false;

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
