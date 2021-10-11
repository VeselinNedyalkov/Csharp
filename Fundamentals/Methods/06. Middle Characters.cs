using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            if (word.Length % 2 == 0)
            {
                Console.WriteLine(EvenChars(word));
            }
            else
            {
                Console.WriteLine(OddChar(word));
            }
        }

        static string EvenChars(string word)
        {
            string result = string.Empty;
            char temp = word[(word.Length / 2) - 1];
            for (int i = 0; i < 2; i++)
            {               
                result += temp;
                temp = word[word.Length / 2];
            }
            return result;
        }

        static char OddChar(string word)
        {
            char result = word[word.Length / 2];
            return result;
        }
    }
}
