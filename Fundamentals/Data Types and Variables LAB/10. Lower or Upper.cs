using System;

namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char abv = char.Parse(Console.ReadLine());

            if (abv >= 65 && abv <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else if (abv >= 97 && abv <= 122)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
