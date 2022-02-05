using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> collection = new List<string>
            {   "pear",

                "flour",

                "pork",

                "olive"
            };
            HashSet<char> matchChars = new HashSet<char>();

            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(' ')
                 .Select(char.Parse).ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(' ')
                .Select(char.Parse).ToArray());

            //take all chars that are present and save them in HashSet<char> matchChars
            while (consonants.Count != 0)
            {
                char vowel = vowels.Dequeue();
                vowels.Enqueue(vowel);
                char consonant = consonants.Pop();

                foreach (var word in collection)
                {
                    if (word.Contains(vowel))
                    {
                        matchChars.Add(vowel);
                    }

                    if (word.Contains(consonant))
                    {
                        matchChars.Add(consonant);
                    }
                }              
            }
            List<string> endCollection = new List<string>();


            //check if all chars are present in one word if coounter == word.lenght
            foreach (var words in collection)
            {
                int allPresent = 0;
                foreach (var chars in matchChars)
                {

                    if (words.Contains(chars))
                    {
                        allPresent++;
                    }
                }
                if (words.Length == allPresent)
                {
                    endCollection.Add(words);
                }
            }
            Console.WriteLine($"Words found: {endCollection.Count}");
            Console.WriteLine(string.Join("\n", endCollection));
        }
    }
}
