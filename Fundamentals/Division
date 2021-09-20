using System;

namespace _02.Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int devider = int.MinValue;

            if (num % 2 == 0)
            {
                if (devider < 2)
                {
                    devider = 2;
                }
            }
            if (num % 3 == 0)
            {
                if (devider < 3)
                {
                    devider = 3;
                }
            }
            if (num % 6 == 0)
            {
                if (devider < 6)
                {
                    devider = 6;
                }
            }
            if (num % 7 == 0)
            {
                if (devider < 7)
                {
                    devider = 7;
                }
            }
            if (num % 10 == 0)
            {
                if (devider < 10)
                {
                    devider = 10;
                }
            }

            if (devider == int.MinValue)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
                Console.WriteLine($"The number is divisible by {devider}");
            }
            
        }//end
    }
}
