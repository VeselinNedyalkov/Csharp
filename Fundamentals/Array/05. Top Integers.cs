using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            

            for (int i = 0; i < numbers.Length; i++)
            {
                bool isItTheBiggest = true;
                for (int k = i + 1; k < numbers.Length; k++)
                {
                    //14 24 3 19 15 17  ->  24 19 17
                    if (numbers[i] <= numbers[k])
                    {
                        isItTheBiggest = false;
                    }
                   
                }
                if (isItTheBiggest)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}
