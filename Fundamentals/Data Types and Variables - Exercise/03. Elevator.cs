using System;
using System.ComponentModel;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            double numPeople = int.Parse(Console.ReadLine());
            double elevatorCap = int.Parse(Console.ReadLine());
            double courses = 0;

            courses = numPeople / elevatorCap;
            courses = Math.Ceiling(courses);

             Console.WriteLine(courses);                      
        }
    }
}
