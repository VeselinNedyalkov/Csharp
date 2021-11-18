using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {                             
            string input = Console.ReadLine();
            string patern = @"\b(?<date>[0-9]{2})(?<simvol>[\/\.\-])(?<month>[A-Z][a-z]{2})\2(?<year>[0-9]{4})\b";
           
            MatchCollection matchDate = Regex.Matches(input , patern);
                

            foreach (Match date in matchDate)
            {
                string day = date.Groups["date"].Value;
                string month = date.Groups["month"].Value;
                string year = date.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
