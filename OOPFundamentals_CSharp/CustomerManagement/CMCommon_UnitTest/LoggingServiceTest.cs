using CM_Common;
using CustomerManagement_BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CMCommon_UnitTest
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void WriteToFileTest()
        {
            //arrange
            var changedItems = new List<ILoggable>();

            var customer = new Customer(1)
            {
                EmailAdress = "sakurakinomoto@cardcaptors.com",
                FirstName = "Sakura",
                LastName = "Kinomoto",
                AddressList = null
            };

            changedItems.Add(customer);

            var product = new Product(2)
            {
                ProductName = "Clow Cards",
                ProductDescription = "Complete deck with 52 magic cards designed by the half british half chinese magician Clow Reed.",
                CurrentPrice = 200.50M
            };

            changedItems.Add(product);

            //act
            LoggingService.WriteToFile(changedItems);
        }
    }
}
