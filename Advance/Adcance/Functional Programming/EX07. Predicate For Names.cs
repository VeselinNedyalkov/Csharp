using System;
using System.Linq;

namespace Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wordLenght = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> checkLenght = name => name.Length <= wordLenght;

            names.Where(x => checkLenght(x)).ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}




//Write a program that filters a list of names according to their length. 
//On the first line, you will be given an integer n, representing a name's length. On the second line, 
//you will be given some names as strings separated by space. 
//Write a function that prints only the names whose length is less than or equal to n.
