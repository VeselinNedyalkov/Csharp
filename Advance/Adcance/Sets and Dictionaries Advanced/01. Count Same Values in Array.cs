using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionaries_Advanced_Lab
{
    internal class Program
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> numDictionary = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numDictionary.ContainsKey(numbers[i]))
                {
                    numDictionary[numbers[i]]++;
                }
                else
                {
                    numDictionary.Add(numbers[i], 1);
                }
            }

            foreach (var num in numDictionary)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}



//Write a program that counts in a given array of double values the number of occurrences of each value. 
