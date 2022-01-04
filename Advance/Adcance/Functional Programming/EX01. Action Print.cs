using System;
using System.Linq;

namespace Functional_Programming___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = msg => Console.WriteLine(msg);

            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList().ForEach(x => print(x));


        }
    }
}




//Create a program that reads a collection of strings from the console and then prints them onto the console. 
//Each name should be printed on a new line.Use Action<T>.

