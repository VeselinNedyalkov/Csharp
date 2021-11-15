using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<string> codedWord = new List<string>(2);
            string input = Console.ReadLine();
            

            while (input != "find")
            {               
                codedWord.Add(input);
                
                input = Console.ReadLine();
            }
            
            StringBuilder uncoding = new StringBuilder();
            string[] lastWord = new string[4];

            for (int i = 0; i < codedWord.Count; i++)
            {
                string workingWord = codedWord[i];
                int k = 0;
                int j = 0;
                do
                {
                    int number = numbers[k];
                    char temp = workingWord[j];
                    char apeend = (char)(temp - number);
                    uncoding.Append(apeend.ToString());
                    j++;
                    k++;
                    if (k == numbers.Length)
                    {
                        k = 0;
                    }
                }
                while (j != workingWord.Length);

                uncoding.Replace('&', ' ').Replace('>',' ').Replace('<', ' ');

                string tempOne = uncoding.ToString().Trim();
                lastWord = tempOne.Split(" ");

                Console.WriteLine($"Found {lastWord[1]} at {lastWord[lastWord.Length- 1]}");
                uncoding.Clear();
            }
           
        }
    }
}
