using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public double Average { get; private set; }
        public double Highest { get; private set; }
        public double Lowest { get; private set; }
        public char Letter { get; private set; }
        private double Sum { get; set; }
        private int Counter { get; set; }

        public Statistics()
        {
            Highest = double.MinValue;
            Lowest = double.MaxValue;
            Average = 0.0;
            Sum = 0.0;
            Counter = 0;
        }

        public void Add(double grade)
        {
            Sum += grade;
            Counter++;
            Highest = Math.Max(grade, Highest);
            Lowest = Math.Min(grade, Lowest);
            Average = Sum / Counter;
            switch (Average)
            {
                case var letter when letter >= 90.0:
                    Letter = 'A';
                    break;

                case var letter when letter >= 80.0:
                    Letter = 'B';
                    break;

                case var letter when letter >= 70.0:
                    Letter = 'C';
                    break;

                case var letter when letter >= 60.0:
                    Letter = 'D';
                    break;

                default:
                    Letter = 'F';
                    break;
            }
        }
    }
}
