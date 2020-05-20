using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book 
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade) 
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics() 
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.Highest = double.MinValue;
            result.Lowest = double.MaxValue;
            foreach (double grade in this.grades)
            {
                result.Highest = Math.Max(grade, result.Highest);
                result.Lowest = Math.Min(grade, result.Lowest);
                result.Average += grade;
            }
            result.Average /= this.grades.Count;

            return result;
        }

        List<double> grades;
        string name;
    }
}