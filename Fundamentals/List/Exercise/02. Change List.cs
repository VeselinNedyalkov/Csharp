using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            string[] comands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (comands[0] != "end")
            {
                switch (comands[0])
                {
                    case "Delete":
                        numbers.RemoveAll(x => x == int.Parse(comands[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(comands[2]), int.Parse(comands[1]));
                        break;
                    default:
                        break;
                }
                comands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
