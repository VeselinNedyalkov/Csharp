using System;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split("@").Select(int.Parse).ToArray();
            string[] cupidonJums = Console.ReadLine().Split();
            int cupidonIndex = 0;
            const int CIPIDON_POWER = 2;

            while (cupidonJums[0] != "Love!")
            {
                int jumpDistance = int.Parse(cupidonJums[1]);

                if (cupidonIndex + jumpDistance > neighborhood.Length - 1)
                    cupidonIndex = 0;
                else
                    cupidonIndex += jumpDistance;

                if (neighborhood[cupidonIndex] == 0)
                    Console.WriteLine($"Place {cupidonIndex} already had Valentine's day.");
                else
                {
                    neighborhood[cupidonIndex] -= CIPIDON_POWER;
                    if (neighborhood[cupidonIndex] == 0)
                    {
                        Console.WriteLine($"Place {cupidonIndex} has Valentine's day.");
                    }
                }
                cupidonJums = Console.ReadLine().Split();
            }//while
            Console.WriteLine($"Cupid's last position was {cupidonIndex}.");
            if (neighborhood.Count(x => x != 0) == 0)
                Console.WriteLine("Mission was successful.");
            else
                Console.WriteLine($"Cupid has failed {neighborhood.Count(x => x != 0)} places.");



        }
    }
}
