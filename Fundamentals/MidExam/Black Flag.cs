using System;

namespace MidExzamTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysPlundering = int.Parse(Console.ReadLine());
            int dailyPlunderMoney = int.Parse(Console.ReadLine());
            int expectedPlunder = int.Parse(Console.ReadLine());
            double totalPlunder = 0;

            for (int i = 1; i <= daysPlundering; i++)
            {
                totalPlunder += dailyPlunderMoney;
                if (i % 3 == 0)
                {
                    totalPlunder += dailyPlunderMoney * 0.50;
                }
                if (i % 5 == 0)
                {
                    totalPlunder -= totalPlunder * 0.30;
                }
            }//for

            if (expectedPlunder <= totalPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double procentsCollected = (totalPlunder / expectedPlunder) * 100;
                Console.WriteLine($"Collected only {procentsCollected:f2}% of the plunder.");
            }
        }

    }
}
