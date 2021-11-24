using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"([#|\|])(?<name>[A-Za-z\s]+)\1(?<expDate>[0-9]{2,2}\/[0-9]{2,2}\/[0-9]{2,2})\1(?<calories>[0-9]{1,5})\1";
            string input = Console.ReadLine();
            const int CAL_PER_DAY = 2000;

            MatchCollection food = Regex.Matches(input, patern);

            string product;
            string date;
            int calories;
            int totalCalories = 0;
            int days = 0;

            //calculate total calories
            foreach (Match match in food)
            {              
                calories = int.Parse(match.Groups["calories"].Value);
                totalCalories += calories;
            }   
            //calculate for how many days we have food
            days = totalCalories / CAL_PER_DAY;

            Console.WriteLine($"You have food to last you for: {days} days!");
            //print
            foreach (Match match in food)
            {
                product = match.Groups["name"].Value;
                date = match.Groups["expDate"].Value;
                calories = int.Parse(match.Groups["calories"].Value);
                Console.WriteLine($"Item: {product}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}
