using System;
using System.Linq;
using System.Collections.Generic;

namespace Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int lenght = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < lenght; i++)
            {
                int[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                

                switch (cmd[0])
                {
                    case 1:
                        int num = cmd[1];
                        numbers.Push(num);
                        break;

                    case 2:
                        if (numbers.Count != 0)
                            numbers.Pop();
                        break;

                    case 3:
                        if(numbers.Count != 0)
                            Console.WriteLine(numbers.ToArray().Max());
                        break;

                    case 4:
                        if (numbers.Count != 0)
                            Console.WriteLine(numbers.ToArray().Min());
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
