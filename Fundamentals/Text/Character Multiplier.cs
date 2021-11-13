using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string first = input[0];
            string second = input[1];

            int sum = 0;
            int longestString = Math.Max(first.Length, second.Length);

            for (int i = 0; i < longestString; i++)
            {
                int firstNum;
                if (i > first.Length - 1)
                    firstNum = 0;
                else
                    firstNum = first[i];

                int secondNum;
                if (i > second.Length - 1)
                    secondNum = 0;
                else
                    secondNum = second[i];

                if (firstNum != 0 && secondNum != 0)
                    sum += firstNum * secondNum;
                else
                    sum += firstNum + secondNum;
            }
            Console.WriteLine(sum);
        }
    }
}
