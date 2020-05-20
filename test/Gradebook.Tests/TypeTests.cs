using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void ValueTypesCanBePassedRef()
        {
            var x = GetInt();
            SetInt(out x);

            Assert.Equal(42, x);
        }

        private void SetInt(out int x)
        {
            x = 42;
        }

        [Fact]
        public void ValueTypesPassByValue()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
           var book1 = GetBook("Book 1");
           ResetBookSetName(out book1, "New Name");

           Assert.Equal("New Name", book1.Name);
        }

        private void ResetBookSetName(out Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpByDefaultWillPassByValue()
        {
           var book1 = GetBook("Book 1");
           GetBookSetName(book1, "New Name");

           Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
           var book1 = GetBook("Book 1");
           SetName(book1, "New Name");

           Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Craig";
            // This will not change "name" - strings are immutable
            MakeUppercase(name);
            string upperName = ReturnUppercase(name);

            Assert.Equal("Craig", name);
            Assert.Equal("CRAIG", upperName);
        }

        private string ReturnUppercase(string name)
        {
            return name.ToUpper();
        }

        private void MakeUppercase(string aString)
        {
            aString.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
           var book1 = GetBook("Book 1");
           var book2 = GetBook("Book 2");

           Assert.Equal("Book 1", book1.Name);
           Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
