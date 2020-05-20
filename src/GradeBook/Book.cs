using System;
using System.Collections.Generic;

namespace GradeBook
{
    // Event delegate example
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book 
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.Name = name;
        }
        public void AddGrade(double grade) 
        {
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else 
            {
                throw new ArgumentException($"Invalid {nameof(grade)} value");
            }
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics() 
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.Highest = double.MinValue;
            result.Lowest = double.MaxValue;
            
            for (var index = 0; index < this.grades.Count; index++)
            {
                result.Highest = Math.Max(grades[index], result.Highest);
                result.Lowest = Math.Min(grades[index], result.Lowest);
                result.Average += grades[index];
            }
            result.Average /= this.grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60:
                    result.Letter = 'D';
                    break;
                case var d when d >= 50:
                    result.Letter = 'E';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        private List<double> grades;
        // Special property type allows "Name" to be "got" and "set"
        public string Name
        {
            get;
            set;
        }
    }
}