using System;

namespace _01._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meter = int.Parse(Console.ReadLine());

            decimal km = meter / 1000.0m ;
            
            Console.WriteLine($"{km:f2}");
        }
    }
}
