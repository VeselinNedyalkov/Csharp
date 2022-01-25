using System;

namespace Telephony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] webAdres = Console.ReadLine().Split();
            Stationary stationaryPhone = new Stationary();
            Smartphone smartphone = new Smartphone();

            foreach (var num in numbers)
            {
                if (num.Length == 10)
                {
                    smartphone.Calling(num);
                }
                else
                {
                    stationaryPhone.Calling(num);

                }
            }

            foreach (var site in webAdres)
            {
                try
                {
                    smartphone.Browsing(site);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
