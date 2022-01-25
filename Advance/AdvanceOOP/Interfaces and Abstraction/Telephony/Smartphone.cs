using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
       
        public void Browsing(string webAdres)
        {
            if (webAdres.Any(x => char.IsNumber(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {webAdres}!");

            }
        }

        public void Calling(string number)
        {
            if (number.Any(x => char.IsLetter(x) || char.IsSymbol(x)))
                Console.WriteLine("Invalid number!");
            else
                Console.WriteLine($"Calling... {number}");

        }
    }
}
