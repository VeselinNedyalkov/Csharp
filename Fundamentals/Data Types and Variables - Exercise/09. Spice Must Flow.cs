using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int spice = int.Parse(Console.ReadLine());
            int totalProduce = 0;
            int days = 0;
            int reduceByDay = 10;
            int reduceByCrew = 26;

            while (spice >= 100)
            {
                days++;
                totalProduce += spice;
                if (totalProduce > 26)
                {
                    totalProduce -= reduceByCrew;
                }
                         
                spice -= reduceByDay;
            }

            int total = totalProduce > 26 ? totalProduce - reduceByCrew : totalProduce;
            Console.WriteLine($"{days}{Environment.NewLine}{total}");
        }
    }
}
