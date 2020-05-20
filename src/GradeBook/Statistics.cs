using System;

namespace GradeBook
{
    public class Statistics {
        public double Average;
        public double Highest;
        public double Lowest;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';
                    case var d when d >= 80:
                        return 'B';
                    case var d when d >= 70:
                        return 'C';
                    case var d when d >= 60:
                        return 'D';
                    case var d when d >= 50:
                        return 'E';
                    default:
                        return 'F';
                }
            }
        }

        private int SetCount = 0;
        private double Total = 0.0;
        public Statistics()
        {
            Average = 0.0;
            Highest = double.MinValue;
            Lowest = double.MaxValue;
        }

        public void SetValue(double value)
        {
            SetCount++;
            Total += value;
            Highest = Math.Max(value, Highest);
            Lowest = Math.Min(value, Lowest);
            Average = Total / SetCount;
        }
    }
}