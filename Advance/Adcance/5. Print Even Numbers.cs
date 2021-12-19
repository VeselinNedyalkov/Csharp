using System;
using System.Linq;
using System.Collections.Generic;

namespace Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> evenNum = new Queue<int>();

            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                {
                    evenNum.Enqueue(num);
                }
            }

            Console.WriteLine(string.Join(", ", evenNum));
        }
    }
}


//Create a program that:
//•	Reads an array of integers and adds them to a queue
//•	Prints the even numbers separated by ", "
