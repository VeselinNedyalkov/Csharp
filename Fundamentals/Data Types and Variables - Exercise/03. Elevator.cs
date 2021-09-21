using System;
using System.ComponentModel;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());
            int elevatorCap = int.Parse(Console.ReadLine());
            double courses = 0;

            courses = numPeople / elevatorCap;
            courses = Math.Ceiling(courses);

            if (numPeople <= elevatorCap)
{
                Console.WriteLine($"All the persons fit inside in the elevator.{Environment.NewLine}Only one course is needed.");
            }
            else
            {
                Console.WriteLine($"{courses} courses * {elevatorCap} people{Environment.NewLine}+ 1 course * {numPeople % elevatorCap} persons");
            }

        }
    }
}
