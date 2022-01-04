using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            //delegate to check if char sum is more or equal to num
            Func<string, int, bool> sumChar = (word, eqOrLar) =>
            {
                int sum = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    sum += word[i];
                }
                return sum >= eqOrLar;
            };
            //method that check the words from names till faind the 1st one
            CheckCharNum(num, names, sumChar);          
        }

        private static void CheckCharNum(int num, string[] names, Func<string, int, bool> sumChar)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (sumChar(names[i], num))
                {
                    Console.WriteLine(names[i]);
                    return;
                }
                   
            }
        }
    }
}



//Create a program that traverses a collection of names and returns the first name,
// whose sum of characters is equal to or larger than a given number N,
// which will be given on the first line. Use a function that accepts another function as one of its parameters.
// Start by building a regular function to hold the basic logic of the program. 
//Something along the lines of Func<string, int, bool>. 
//Afterward, create your main function which should accept the first function as one of its parameters.

