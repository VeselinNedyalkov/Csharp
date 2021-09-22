using System;

namespace _02._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
           double  britishPound = double.Parse(Console.ReadLine());
            //1 British Pound = 1.31 Dollars
            
            decimal US = (decimal)britishPound * (decimal)1.31;

            Console.WriteLine($"{US:f3}");
        }
    }
}
