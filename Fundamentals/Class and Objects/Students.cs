using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int infoStudents = int.Parse(Console.ReadLine());
            List<Student> studentsList = new List<Student>();

            for (int i = 0; i < infoStudents; i++)
            {
                string[] studentInput = Console.ReadLine().Split();

                string firstName = studentInput[0];
                string lastName = studentInput[1];
                double grade = double.Parse(studentInput[2]);
                Student studentClass = new Student(firstName, lastName, grade);
                studentsList.Add(studentClass);
            }
            studentsList = studentsList.OrderByDescending(x => x.Grade).ToList();
            foreach (Student item in studentsList)
            {
                Console.WriteLine(item);
            }
        }
    }//class Program

    class Student
    {
        public Student(string firstName , string lastName , double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }//class student
}
