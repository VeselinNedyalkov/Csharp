using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            int inputInfo = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputInfo; i++)
            {
                string[] student = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = student[0];
                decimal grade = decimal.Parse(student[1]);

                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<decimal>() { grade });
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x => x.ToString("f2")))}" +
                    $" (avg: {student.Value.Average():f2})");
            }
        }
    }
}


//Write a program, which reads a name of a student and his/her grades and adds them to the student record,
//then prints the student's names with their grades and their average grade.
