using System;
using System.Text.RegularExpressions;

namespace Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputNumbers = Console.ReadLine();

            string patern = @"\+[3][5][9]([\ \-])[2]\1[0-9]{3}\1[0-9]{4}\b";
            Regex regex = new Regex(patern);

            MatchCollection matchNumbers = regex.Matches(inputNumbers);

            Console.WriteLine(string.Join(", ", matchNumbers));
        }
    }
}
