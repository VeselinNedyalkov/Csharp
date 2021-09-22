using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int num1 = 0;
            int num2 = 0;
            int sum = 0;

            for (int i = 1; i <= num; i++)
            {
                num1 = i % 10;
                num2 = i / 10;
                sum = num1 + num2; 
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
                
            }
            
        }
    }
}
