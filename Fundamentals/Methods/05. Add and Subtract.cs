using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum1and2 = SumOneAndTwo(num1, num2);
            int result = MinusSumAndThre(sum1and2, num3);
            Console.WriteLine(result);
        }

        static int SumOneAndTwo(int num1,int num2)
        {
            return num1 + num2;
        }

        static int MinusSumAndThre(int sum1and2, int num3 )
        {
            return sum1and2 - num3;
        }
    }
}
