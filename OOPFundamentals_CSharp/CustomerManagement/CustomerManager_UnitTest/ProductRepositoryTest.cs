using CustomerManagement_BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CMBL_UnitTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void RetrieveValidate()
        {
            //arrange
            var productRepository = new ProductRepository();
            var expected = new Product(2);
            expected.ProductName = "Clow Cards";
            expected.ProductDescription = "Complete deck with 52 magic cards designed by the half british half chinese magician Clow Reed.";
            expected.CurrentPrice = 200.50M;

            //act
            var result = productRepository.Retrieve(2);

            //assert
            Assert.AreEqual(expected.ProductId, result.ProductId);
            Assert.AreEqual(expected.ProductName, result.ProductName);
            Assert.AreEqual(expected.ProductDescription, result.ProductDescription);
            Assert.AreEqual(expected.CurrentPrice, result.CurrentPrice);
        }
    }
}
