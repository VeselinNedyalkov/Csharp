using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            // •	First – model – string.
            //•	Second –radius – floating - point number
            //•	Third – height – integer number
            int numKegs = int.Parse(Console.ReadLine());
            double size = 0;
            double maxSize = double.MinValue;
            string maxModel = "";
 
            for (int i = 0; i < numKegs; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                size = Math.PI * Math.Pow(radius,radius) * height;

                if (size > maxSize)
                {
                    maxSize = size;
                    maxModel = model;
                }
                size = 0;
            }

            Console.WriteLine(maxModel);
        }
    }
}
