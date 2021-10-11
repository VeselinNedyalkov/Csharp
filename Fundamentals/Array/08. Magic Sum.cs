using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int equalTo = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersArr.Length - 1; i++)
            {
                for (int k = i + 1; k < numbersArr.Length; k++)
                {
                    if (numbersArr[i] + numbersArr[k] == equalTo)
                    {
                        Console.WriteLine($"{numbersArr[i]} {numbersArr[k]}");
                    }
                }
            }
        }
    }
}
