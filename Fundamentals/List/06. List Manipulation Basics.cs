using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "end")
            {
                switch (input[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(input[1]));
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(input[1]));
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(input[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
