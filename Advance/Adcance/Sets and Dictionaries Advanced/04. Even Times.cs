using System;
using System.Collections.Generic;

namespace Even_time
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Dictionary<int , int> bagOfNumbers = new Dictionary<int, int>();

            int numbers = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < numbers; i++)
            {
                int inputNum = int.Parse(Console.ReadLine());

                if (!bagOfNumbers.ContainsKey(inputNum))
                {
                    bagOfNumbers.Add(inputNum, 1);
                }
                else
                {
                    bagOfNumbers[inputNum]++;
                }
            }

            foreach (var num in bagOfNumbers)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }

    }
}
