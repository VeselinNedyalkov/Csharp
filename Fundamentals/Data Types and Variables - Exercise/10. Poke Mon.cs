using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rabotnoN = n;
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int counter = 0;

            while (rabotnoN >= m)
            {
                rabotnoN -= m;
                counter++;

                if (rabotnoN == n * 0.5 && y != 0)
                {
                    rabotnoN /= y;
                }
            }

            Console.WriteLine($"{rabotnoN}{Environment.NewLine}{counter}");
        }
    }
}
