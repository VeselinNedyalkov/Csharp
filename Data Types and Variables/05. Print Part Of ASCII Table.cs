using System;

namespace _05._PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char charSim = ' ';

            for (int i = num1; i <= num2; i++)
            {
                charSim = (char)i;
                Console.Write($"{charSim} ");
            }
        }
    }
}
