using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    // Event delegate example
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    // NamedObject for Inheritence example
    public class NamedObject
    {
        public NamedObject(string name)
        {
            this.Name = name;
        }

        // Special property type allows "Name" to be "got" and "set"
        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            string filename = $"{this.Name}.txt";
            // Wrap gradefile in "using" statement so that the Dispose/Close method is called
            // as it implements the IDisposable interface.
            using (var gradefile = File.AppendText(filename))
            {
                gradefile.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            string filename = $"{this.Name}.txt";
            // Wrap gradefile in "using" statement so that the Dispose/Close method is called
            // as it implements the IDisposable interface.
            using (var gradefile = File.OpenText(filename))
            {
                while (true) {
                    var gradeLine = gradefile.ReadLine();
                    if (String.IsNullOrEmpty(gradeLine))
                        break;
                    var grade = double.Parse(gradeLine);
                    result.SetValue(grade);
                }
            }
            return result;
        }

    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            //this.Name = name;
        }
        public override void AddGrade(double grade) 
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

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics() 
        {
            var result = new Statistics();
            for (var index = 0; index < this.grades.Count; index++)
            {
                result.SetValue(grades[index]);
            }
            return result;
        }

        private List<double> grades;
    }
}