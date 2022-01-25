using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Stationary : ICalling
    {
      
        public void Calling(string number)
        {
            if (number.Any(x => char.IsLetter(x) || char.IsSymbol(x)))
                Console.WriteLine("Invalid number!");

            else
                Console.WriteLine($"Dialing... {number}");

        }
    }
}
