using System;

namespace MidExamFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());
            double totalCost = 0;

            totalCost += apronPrice * (students + Math.Ceiling(students * 0.2));  //apron calculations
            totalCost += eggPrice * 10 * students;                              //eggs calculations
            double freePackages = Math.Floor(students / 5);                     //free packages calculations
            totalCost += flourPrice * (students - freePackages);                //flour calculations

            if (totalCost <= budget)
                Console.WriteLine($"Items purchased for {totalCost:f2}$.");
            else
                Console.WriteLine($"{totalCost - budget:f2}$ more needed.");
        }
    }
}
