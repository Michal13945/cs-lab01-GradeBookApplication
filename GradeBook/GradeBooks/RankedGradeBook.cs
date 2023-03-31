using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
           if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var sortedStudents = Students.OrderByDescending(student => student.AverageGrade).ToList();
            int studentIndex = -1;

            for (int i = 0; i < sortedStudents.Count; i++)
            {
                if (sortedStudents[i].AverageGrade < averageGrade)
                {
                    studentIndex = i;
                    break;
                }
            }

           if(studentIndex == -1)
            {
                return 'F';
            }
            else
            {
                double placement = ((double)studentIndex / sortedStudents.Count) * 100;
                Console.WriteLine(placement + "%");


                switch (placement) 
                {
                    case double number when (number >= 0 && number <= 20):
                        return 'A';
                    case double number when (number >= 20 && number <= 40):
                        return 'B';
                    case double number when (number >= 40 && number <= 60):
                        return 'C';
                    case double number when (number >= 60 && number <= 80):
                        return 'D';
                    default:
                        return 'F';
                }

            }
        
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
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
