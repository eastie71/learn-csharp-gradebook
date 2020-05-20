using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStatistics()
        {
            // Arrange
            var book = new Book("Test");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            // Should not add invalid grade
            try {
                book.AddGrade(105);
            }
            catch(ArgumentException ex) 
            {
                Console.WriteLine("Add Grade failed as expected.");
                Console.WriteLine(ex.Message);
            }
            
            // Act
            var results = book.GetStatistics();
            // Assert
            Assert.Equal(85.6, results.Average, 1);
            Assert.Equal(90.5, results.Highest, 1);
            Assert.Equal(77.3, results.Lowest, 1);
            Assert.Equal('B', results.Letter);

        }
    }
}
