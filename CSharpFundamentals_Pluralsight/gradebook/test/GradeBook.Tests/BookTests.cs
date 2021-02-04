using System;
using GradeBook;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStats();

            //assert
            //the last parameter set the value point
            Assert.Equal(85.6, result.Average, 1);
        }
    }
}
