using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            Console.WriteLine(SumOfVowels(inputString));
        }

        static int SumOfVowels(string input)
        {
            int result = 0;
            input = input.ToLower();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'e' || input[i] == 'o' || input[i] == 'i' || input[i] == 'u')
                {
                    result++;
                }
            }

            return result;
        }
    }
}
