using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double sum1 = Factorial(num1);
            double sum2 = Factorial(num2);
            double factorial = sum1 / sum2;
            Console.WriteLine($"{factorial:f2}");
        }

        static double Factorial(int num)
        {
            double sum = 1;
            for (int i = num; i >= 2; i--)
            {
                sum *= i;
            }
            return sum;
        }
    }
}
