using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList(); 
            List<int> seconList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();
            int forCicleEnd = Math.Min(firstList.Count, seconList.Count);

            for (int i = 0; i < forCicleEnd; i++)
            {
                result.Add(firstList[i]);
                result.Add(seconList[i]);
            }

            int otherIndexToMax = Math.Max(firstList.Count, seconList.Count);

            for (int i = forCicleEnd; i < otherIndexToMax; i++)
            {
                if (firstList.Count > seconList.Count)
                {
                    result.Add(firstList[i]);
                }
                else
                {
                    result.Add(seconList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
