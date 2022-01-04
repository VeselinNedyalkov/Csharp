using System;
using System.Linq;

namespace Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[] , int> minimum = num => num.Min();

           int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Console.WriteLine(minimum(numbers));
        }
    }
}




//Create a simple program that reads from the console a set of integers 
//and prints back on the console the smallest number from the collection.
// Use Func<T, T>.

