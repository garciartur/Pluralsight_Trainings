using CM_Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CMCommon_UnitTest
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpacesValid()
        {
            //arrange
            var source = "ClowCards";
            var expected = "Clow Cards";

            //act
            var result = source.InsertSpace();

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InsertSpacesWithExistingSpaces()
        {
            //arrange
            var source = "Clow Cards";
            var expected = "Clow Cards";

            //act
            var result = source.InsertSpace();

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
