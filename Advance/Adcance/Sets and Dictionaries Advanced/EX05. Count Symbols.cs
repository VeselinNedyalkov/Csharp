using System;
using System.Collections.Generic;

namespace Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char,int> chars = new SortedDictionary<char,int>();

            string inputString = Console.ReadLine();

            for (int i = 0; i < inputString.Length; i++)
            {
                char temp = inputString[i];

                if (chars.ContainsKey(temp))
                {
                    chars[temp]++;
                }
                else
                {
                    chars.Add(temp, 1);
                }
            }

            foreach (var item in chars)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
