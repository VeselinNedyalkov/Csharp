using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            
            int totalWater = 0;

            for (int i = 0; i < num; i++)
            {
                int newLineWater = int.Parse(Console.ReadLine());               
                if (newLineWater > 255 || totalWater + newLineWater > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    totalWater += newLineWater;
                }                
            }//for

            Console.WriteLine($"{totalWater}");
        }
    }
}
