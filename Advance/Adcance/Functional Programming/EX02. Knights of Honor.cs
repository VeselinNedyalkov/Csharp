using System;
using System.Linq;

namespace Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> printSir = msg => Console.WriteLine($"Sir {msg}");

            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList().ForEach(x => printSir(x));
        }
    }
}



//Create a program that reads a collection of names as strings from the console,
//appends "Sir" in front of every name, and prints it back on the console. Use Action<T>.

