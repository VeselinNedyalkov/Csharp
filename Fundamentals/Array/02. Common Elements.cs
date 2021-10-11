using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] secondArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int k = 0; k < firstArray.Length; k++)
                {
                    if (secondArray[i] == firstArray[k])
                    {
                        Console.Write($"{secondArray[i]} ");
                    }
                }
            }
        }
    }
}
