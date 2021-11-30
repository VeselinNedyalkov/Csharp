
using System;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"([:]{2}|[*]{2})(?<emotion>[A-Z][a-z]{2,})\1";

            string inputWord = Console.ReadLine();

            MatchCollection emotions = Regex.Matches(inputWord, patern);

            ulong coolThreshold = 1;
            foreach (var item in inputWord)//check the inputword for numbers
            {
                if (char.IsDigit(item))//if there is a number add it to the counter
                    coolThreshold *= (ulong)char.GetNumericValue(item);
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");

            Console.WriteLine($"{emotions.Count} emojis found in the text. The cool ones are:");
            foreach (Match item in emotions)//chech the Match
            {
                ulong emotCounter = 0;
                string word = item.Groups["emotion"].Value;//take the VALUE
                //calculate the ASCII ot item
                foreach (var emot in word)
                {
                    emotCounter += emot;
                }
                
                if (coolThreshold < emotCounter)
                {
                    Console.WriteLine(item.Value);
                }
            }
        }
    }
}
