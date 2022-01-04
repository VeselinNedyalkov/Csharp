using System;
using System.Linq;

namespace List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Func<int[], int, bool> isDivided = (dividers, num) =>
            {
              bool isDiv = true;
              for (int i = 0; i < dividers.Length; i++)
              {
                  if (num % dividers[i] != 0)
                  {
                      isDiv = false;
                      break;
                  }
              }
              return isDiv;
            };

            for (int i = 1; i <= number; i++)
            {
                if(isDivided(numbers,i))
                    Console.Write($"{i} ");
            }
        }
    }
}





//Write a program that filters a list of names according to their length. 
//On the first line, you will be given an integer n, representing a name's length. On the second line, 
//you will be given some names as strings separated by space. 
//Write a function that prints only the names whose length is less than or equal to n.

