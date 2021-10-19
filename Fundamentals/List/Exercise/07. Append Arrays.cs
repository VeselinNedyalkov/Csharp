using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> answer = new List<string>(numbers.Count);
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                List<string> temp = numbers[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                answer.AddRange(temp);
                
            }

            Console.Write(string.Join(" ", answer));
        }
    }
}
