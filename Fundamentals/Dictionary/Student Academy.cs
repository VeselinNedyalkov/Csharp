using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> studentsGrade = new Dictionary<string, double>();

            int studentNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentNumbers; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsGrade.ContainsKey(name))
                {
                    studentsGrade.Add(name, grade);
                }
                else
                {
                    grade = (studentsGrade[name] + grade) / 2;
                    studentsGrade[name] = grade;
                }

            }//for

            studentsGrade = studentsGrade.OrderByDescending(x => x.Value).ToDictionary(y => y.Key, y => y.Value);
            const double MIN_GRADE = 4.50;

            foreach (var student in studentsGrade)
            {
                if (student.Value >= MIN_GRADE)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value:f2}");
                }
            }


        }
    }
}
