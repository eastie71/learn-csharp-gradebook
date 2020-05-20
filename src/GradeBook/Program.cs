using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Craig's Grade Book");   
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);
            
            while(true) {
                Console.Write("Please a Grade between 0 and 100 (or \"q\" to end entry) : ");
                string input = Console.ReadLine();
                if (input.ToLower().Equals("q"))
                    break;

                try {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var stats = book.GetStatistics();
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.Highest:N1}");
            Console.WriteLine($"The lowest grade is {stats.Lowest:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
