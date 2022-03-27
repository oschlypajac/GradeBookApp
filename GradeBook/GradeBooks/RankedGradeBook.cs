using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            //todo
            List<double> averageGrades = new List<double> { averageGrade };
            foreach (var item in Students)
            {
                averageGrades.Add(item.AverageGrade);
            }
            averageGrades.Sort();
            int index = averageGrades.IndexOf(averageGrade);
            double num = index / averageGrades.Count;
            if (num >= 0.8)
            {
                return 'A';
            }
            else if (num >= 0.6)
            {
                return 'B';
            }
            else if (num >= 0.4)
            {
                return 'C';
            }
            else if (num >= 0.2)
            {
                return 'D';
            }
            else
            {
                return 'F';
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
