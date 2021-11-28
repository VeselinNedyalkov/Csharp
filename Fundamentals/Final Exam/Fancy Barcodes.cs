using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"[@][#]+(?<code>([A-Z][A-Za-z0-9]{4,}[A-Z]))[@][#]+";

            int numberBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberBarcodes; i++)
            {
                string inputBarcode = Console.ReadLine();
                Match barCode = Regex.Match(inputBarcode, patern);

                if (barCode.Success)
                {
                    string group = "";
                    string code = barCode.Groups["code"].Value;
                    foreach (var item in code)
                    {
                        if(char.IsDigit(item))
                            group += item;
                    }

                    if (group == "")                   
                        Console.WriteLine("Product group: 00");                    
                    else
                        Console.WriteLine($"Product group: {group}");
                }
                else
                    Console.WriteLine("Invalid barcode");
            }
        }
    }
}
