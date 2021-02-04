using System;
using GradeBook;
using Xunit;

namespace GradeBook.Tests
{
    //creating a delegate - it's like a interface but it's a variable that points to a implemented method
    //you need to define the delegate return and parameters, like a method
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void DelegateCanPointToMethod()
        {         
            WriteLogDelegate log;
            //link the method
            log = ReturnMessage;

            //calling the method using the delegate variable to point to it
            var result = log("Hello!");
            Assert.Equal("Hello!", result);
        }
        
        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void GetBookReturnDifferentObjects()
        {
            //arrange
            var bookA = GetBook("Book A");
            var bookB = GetBook("Book B");

            //assert
            Assert.Equal("Book A", bookA.Name);
            Assert.Equal("Book B", bookB.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange
            var bookA = GetBook("Book A");
            var bookB = bookA;

            //assert
            Assert.Same(bookA, bookB);
            //verifying if the var is pointing to the same object
            Assert.True(Object.ReferenceEquals(bookA, bookB));
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange
            var bookA = GetBook("Book A");
            SetName(bookA, "New name");

            //assert
            Assert.Equal("New name", bookA.Name);
        }

        [Fact]
        public void CSharpPassByValue()
        {
            //arrange
            var bookA = GetBook("Book A");
            GetBookSetName(bookA, "New name");

            //assert
            Assert.Equal("Book A", bookA.Name);
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            //arrange
            var bookA = GetBook("Book A");
            GetBookSetNameRef(ref bookA, "New name");

            //assert
            Assert.Equal("New name", bookA.Name);
        }

        [Fact]
        public void ChangingValueByReference()
        {
            //arrange
            var x = GetInt();
            SetInt(ref x);

            //assert
            Assert.Equal(42, x);
        }

        [Fact]
        public void StringsBehaveLikeValueType()
        {
            string name = "Artur";
            var upper = MakeUppeCase(name);

            Assert.Equal("Artur", name);
            Assert.Equal("ARTUR", upper);
        }

        [Fact]
        public void WhenAverageis90LetterIsA()
        {
            var book = GetBook("Test");

            book.AddGrade(90);
            var stats = book.GetStats();
            var result = stats.Letter;

            Assert.True(result == 'A');
        }

        private string MakeUppeCase(string name)
        {
            return name.ToUpper();
        }

        private int GetInt()
        {
            return 3;
        }

        private void SetInt(ref int number)
        {
            number = 42;
        }

        //the word REF or OUT guarantee that it'll pass the reference
        private void GetBookSetNameRef(ref Book book, string name)
        {
            book = new Book(name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
