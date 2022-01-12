using System;
using System.Linq;
using System.Collections.Generic;

namespace Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> numbersOne = new HashSet<int>();
            HashSet<int> numbersTwo = new HashSet<int>();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numOne = input[0];
            int numTwo = input[1];

            for (int i = 0; i < numOne; i++)
            {
                numbersOne.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < numTwo; i++)
            {
                numbersTwo.Add(int.Parse(Console.ReadLine()));
            }


            foreach (var one in numbersOne)
            {
                foreach (var two in numbersTwo)
                {
                    if (one == two)
                    {
                        Console.Write($"{one} ");
                    }
                }
            }
        }
    }
}
