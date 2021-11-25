using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"([=\/])(?<location>[A-Z][A-Za-z]{2,})\1";
            string  inputLocations = Console.ReadLine();
            int travelPoints = 0;

            MatchCollection locations = Regex.Matches(inputLocations, patern);
            List<string> decodedLocations = new List<string>(); 

            foreach (Match match in locations)
            {
                decodedLocations.Add(match.Groups["location"].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", decodedLocations)}");

            foreach (var item in decodedLocations)
            {
                travelPoints += item.Length;
            }
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
