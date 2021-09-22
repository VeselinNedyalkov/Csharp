using System;

namespace _04._Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            int year = 0;
            int days = 0;
            int hours = 0;
            int min = 0;

            
                year += centuries * 100;
                days += (int)(365.2422 * year);
                hours += days * 24;
                min += hours * 60;
            
            //1 centuries = 100 years = 36524 days = 876576 hours = 52594560 minutes
            Console.WriteLine($"{centuries} centuries = {year:f0} years = {days} days = {hours} hours = {min} minutes");
        }
    }
}
