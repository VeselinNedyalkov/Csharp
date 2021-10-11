using System;
using System.Linq;

namespace Arrays_Exercies
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());

            int[] people = new int[wagons];

            for (int i = 0; i < wagons; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
            }

            for (int k = 0; k < wagons; k++)
            {
                Console.Write($"{people[k]} ");
            }
            Console.WriteLine($"\n{people.Sum()}");
        }
    }
}
