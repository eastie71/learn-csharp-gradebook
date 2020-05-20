using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Craig's Grade Book");
            book.GradeAdded += MyOnGradeAddedMethod;
            book.GradeAdded -= MyOnGradeAddedMethod;
            book.GradeAdded += MyOnGradeAddedMethod;

            EnterGrades(book);

            var stats = book.GetStatistics();
            Console.WriteLine($"Here is the Grades for {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.Highest:N1}");
            Console.WriteLine($"The lowest grade is {stats.Lowest:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                Console.Write("Please a Grade between 0 and 100 (or \"q\" to end entry) : ");
                string input = Console.ReadLine();
                if (input.ToLower().Equals("q"))
                    break;

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void MyOnGradeAddedMethod(object sender, EventArgs e)
        {
            Console.WriteLine("A Grade was Added!!");
        }
    }
}
