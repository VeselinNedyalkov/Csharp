using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                PrintRow(number);
            }
        }

        static void PrintRow(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Console.Write(number + " ");  
            }
            Console.WriteLine();
        }
    }
}
