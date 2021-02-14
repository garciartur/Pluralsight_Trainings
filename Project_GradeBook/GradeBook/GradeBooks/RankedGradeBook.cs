using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int topAverage = 0;

            if (Students.Count < 5)
            {
                throw new InvalidOperationException("You need at least 5 students to use the features!");
            }

            foreach (var student in Students)
            {
                var studentGrade = student.Grades[0];

                if (studentGrade >= averageGrade)
                {
                    topAverage++;
                }
            }

            //you can't divide two integers, you need to cast one of than double or declare the var double
            var studentIndex = (double)topAverage / Students.Count;

            if (studentIndex >= 0 && studentIndex <= 0.2)
            {
                return 'A';
            }
            
            if (studentIndex > 0.2 && studentIndex <= 0.4)
            {
                return 'B';
            }
            
            if (studentIndex > 0.4 && studentIndex <= 0.6)
            {
                return 'C';
            }
            
            if (studentIndex > 0.6 && studentIndex <= 0.8)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
