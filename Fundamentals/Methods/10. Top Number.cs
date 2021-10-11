using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                TopNumber(i);
            }
        }//Main

        static void TopNumber(int num)
        {
            int inputNum = num;
            int temp = 0;
            int sum = 0;
            bool oddDigit = false;

            while (num != 0)
            {
                temp = num % 10;
                num /= 10;
                sum += temp;
                if (temp % 2 == 1)
                {
                    oddDigit = true;
                }
            }
                      
            bool isDivEight = false;
            if (sum % 8 == 0)
            {
                isDivEight = true;
            }            
            
            if (isDivEight && oddDigit)
            {
                Console.WriteLine(inputNum);
            }
        }
    }
}
