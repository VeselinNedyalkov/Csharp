using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"([@#])(?<wordA>[A-Za-z]{3,})\1{2}(?<wordB>[A-Za-z]{3,})\1";
            int countPairs = 0;
            List<string> matchWords = new List<string>();

            string inputWord = Console.ReadLine();

            MatchCollection match = Regex.Matches(inputWord, patern);

            foreach (Match word in match)
            {
                string wordOne = word.Groups["wordA"].Value;
                string wordTwo = word.Groups["wordB"].Value;
                string wordTwoReverce = string.Join("", wordTwo.Reverse());

                if (wordOne == wordTwoReverce)
                {
                    string matched = wordOne + " <=> " + wordTwo;
                    countPairs++;
                    matchWords.Add(matched);
                }

            }

            if (match.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
                Console.WriteLine($"{match.Count} word pairs found!");


            if (countPairs == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {               
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", matchWords));
            }

        }
    }
}
