using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            BigInteger snowballValue = 0;
            BigInteger maxSnowballValue = int.MinValue;
            int snowballSnowMAx = int.MinValue;
            int snowballTimeMax = int.MinValue;
            int snowballQualityMax = int.MinValue;

            for (int i = 0; i < num; i++)
            {

                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                if(snowballTime > 0)
                snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (maxSnowballValue < snowballValue)
                {
                    maxSnowballValue = snowballValue;
                    snowballSnowMAx = snowballSnow;
                    snowballTimeMax = snowballTime;
                    snowballQualityMax = snowballQuality;
                }
            }
            Console.WriteLine($"{snowballSnowMAx} : {snowballTimeMax} = {maxSnowballValue} ({snowballQualityMax})");
        }
    }
}
