using Microsoft.VisualBasic;
using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Integer
            //•	Floating point 
            //•	Characters
            //•	Boolean
            //•	Strings
            string abc = Console.ReadLine();
            while (abc!= "END")
            {
                if (int.TryParse(abc, out _))
                {
                    Console.WriteLine($"{abc} is integer type");
                }
                else if (double.TryParse(abc, out _))
                {
                    Console.WriteLine($"{abc} is floating point type");
                }
                else if (char.TryParse(abc, out _))
                {
                    Console.WriteLine($"{abc} is character type");
                }
                else if (bool.TryParse(abc, out _))
                {
                    Console.WriteLine($"{abc} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{abc} is string type");
                }

                abc = Console.ReadLine();
            }
            

            




        }
    }
}
