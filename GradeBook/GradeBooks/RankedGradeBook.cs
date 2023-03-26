using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
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
            double result = 0;
            int studentIndex = -1;

           for(int i = 0; i < sortedStudents.Count; i++)
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
                double placement = (studentIndex / sortedStudents.Count) * 100;
                            
                if(placement < 20)
                {
                    return 'A';
                }
                else if(placement < 40)
                {
                    return 'B';
                }
                else if(placement < 60)
                {
                    return 'C';
                }
                else if(placement < 80)
                {
                    return 'D';
                }
                else
                {
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
