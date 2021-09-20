using System;

namespace _06.Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int num = number;
            int factorial = 0;

            while (num > 0)
            {
                int currentNum = num % 10;
                num /= 10;
                int curNum = 1;
                for (int i = 1; i <= currentNum; i++)
                {
                    curNum *= i;
                }
                factorial += curNum;
            }
            if (factorial == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
