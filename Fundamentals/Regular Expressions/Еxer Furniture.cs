using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Regular_ExpressionsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> products = new List<string>();
            double totalPrice = 0;
            string patern = @">>(?<product>[A-Za-z\s]+)<<(?<price>\d*(.\d+))!(?<quantity>\d+)";
            string input = Console.ReadLine();

            while (input != "Purchase")
            {
                Match matches = Regex.Match(input, patern, RegexOptions.IgnoreCase);

                if (matches.Success)
                {
                    products.Add(matches.Groups["product"].Value);
                    double price = double.Parse(matches.Groups["price"].Value);
                    int quantity = int.Parse(matches.Groups["quantity"].Value);
                    totalPrice += price * quantity;
                }                 
                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
