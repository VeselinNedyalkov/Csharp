using System;
using System.Linq;

namespace Methods___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            Console.WriteLine(TheSmallestNum(num1, num2, num3));
        }

        static int TheSmallestNum(int num1, int num2, int num3)
        {
            int[] minValue = { num1, num2, num3 };           
            return minValue.Min();
        }
    }
}
