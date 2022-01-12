using System;
using System.Collections.Generic;

namespace Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elemets = new SortedSet<string>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] element = Console.ReadLine().Split();

                for (int j = 0; j < element.Length; j++)
                {
                    elemets.Add(element[j]);
                }
                
            }

            foreach (var item in elemets)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
