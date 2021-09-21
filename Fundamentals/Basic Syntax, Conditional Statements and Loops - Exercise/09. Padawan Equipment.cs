using System;
using System.Drawing;
using System.Reflection.Emit;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentNum = int.Parse(Console.ReadLine());
            double priceLights = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());

            double freeBelt = 0;

            if (studentNum >= 6)
                freeBelt = studentNum / 6;
            
            double spend = priceLights * Math.Ceiling(studentNum * 1.1) + priceRobes * studentNum  + priceBelts * (studentNum - freeBelt);

            if (money >= spend)
            {
                Console.WriteLine($"The money is enough - it would cost {spend:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {spend - money:f2}lv more.");
            }

        }
    }
}
