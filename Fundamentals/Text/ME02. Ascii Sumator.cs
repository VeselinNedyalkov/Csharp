using System;

namespace Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startIndex = char.Parse(Console.ReadLine());
            char endIndex = char.Parse(Console.ReadLine());
            string word = Console.ReadLine();
            int sum = 0;    

            for (int i = 0; i < word.Length; i++)
            {
                char indexOfCurrChar = word[i]; 
                if (startIndex < indexOfCurrChar  && endIndex > indexOfCurrChar)
                {
                    sum += indexOfCurrChar;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
