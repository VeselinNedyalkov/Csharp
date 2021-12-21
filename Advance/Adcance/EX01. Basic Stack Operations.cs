using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_and_Queues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cmd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = cmd[0];
            int s = cmd[1];
            int x = cmd[2];

            Stack<int> numbers = new Stack<int>();

            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < n; i++)
            {
                numbers.Push(inputNumbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if(numbers.Count != 0)
            {
                int min = numbers.ToArray().Min();
                Console.WriteLine(min);
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
