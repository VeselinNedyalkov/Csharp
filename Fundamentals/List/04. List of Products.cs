using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            List<string> products = new List<string>(lenght);

            for (int i = 0; i < lenght; i++)
            {
                string input = Console.ReadLine();
                products.Add(input);
            }

            products.Sort();

            for (int i = 0; i < lenght; i++)
            {
                Console.WriteLine($"{i+1}.{products[i]}");
            }
        }
    }
}
