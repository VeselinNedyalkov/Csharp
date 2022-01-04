using System;
using System.Linq;

namespace Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int decisibleNum = int.Parse(Console.ReadLine());

            Predicate<int> divisible = x => x % decisibleNum != 0;

            numbers.Where(x => divisible(x)).Reverse().ToList()
                .ForEach(x => Console.Write($"{x} "));
        }
    }
}



//Create a program that reverses a collection and removes elements that are divisible by a given integer n.
// Use predicates/functions.
