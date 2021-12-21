using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int s = input[1];
            int x = input[2];

            int[] numbersToAdd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> numbers = new Queue<int>(numbersToAdd);

            for (int i = 0; i < s; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if(numbers.Count != 0)
            {
                Console.WriteLine(numbers.ToArray().Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
