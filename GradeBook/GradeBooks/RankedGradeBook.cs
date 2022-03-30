using System;
using System.Collections.Generic;
using System.Linq;


namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeight) : base(name, IsWeight)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int above_avg = Students.Count(student => student.AverageGrade > averageGrade);
            double students_part = Students.Count * 2 / 10;

            if (above_avg >= 4 * students_part)
            {
                return 'F';
            }
            else if (above_avg >= 3 * students_part)
            {
                return 'D';
            }
            else if (above_avg >= 2 * students_part)
            {
                return 'C';
            }
            else if (above_avg >= students_part)
            { 
                return 'B';
            }
            else
            {
                return 'A';
            }
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
