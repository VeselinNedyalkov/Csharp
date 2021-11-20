using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();
            string paternSTAR = @"[starSTAR]";
            string paterDecoding = @"[^@\-!\:>]*?@(?<planetName>[A-Z][a-z]*)[^@\-!\:>]*?:(?<population>\d+)[^@\-!\:>]*?!(?<attack>[AD])![^@\-!\:>]*?->(?<soldier>\d*)";

            int msgRcv = int.Parse(Console.ReadLine());

            for (int i = 0; i < msgRcv; i++)
            {
                string inputMsg = Console.ReadLine();
                //check how many [s t a r  S T A R] we have
                MatchCollection msg = Regex.Matches(inputMsg, paternSTAR);
                int starDecoding = msg.Count;

                StringBuilder decodetMsg = new StringBuilder();
                //reduce the number of ACSII with the number from starDecoding
                for (int k = 0; k < inputMsg.Length; k++)
                {
                    char temp = (char)(inputMsg[k] - starDecoding);
                    decodetMsg.Append(temp.ToString());
                }
                //make the new word
                string decodingMsg = String.Join("", decodetMsg);
                //decoding the new word
                Match planetAttack = Regex.Match(decodingMsg, paterDecoding);
                //separate the word to Groups and to the proper List
                if (planetAttack.Success)
                {
                    string planetName = planetAttack.Groups["planetName"].Value;
                    int population = int.Parse(planetAttack.Groups["population"].Value);
                    char attack = char.Parse(planetAttack.Groups["attack"].Value);
                    int soldiers = int.Parse(planetAttack.Groups["soldier"].Value);

                    if (attack == 'A')
                        attacked.Add(planetName);
                    else if (attack == 'D')
                        destroyed.Add(planetName);
                }
            }//for
            //Print the text
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var planet in attacked.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var planet in destroyed.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
           
            
        }
    }
}
