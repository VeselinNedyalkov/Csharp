using System;

namespace _04.SumОfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numChar = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < numChar; i++)
            {
                char input = char.Parse(Console.ReadLine());
                sum += input;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
