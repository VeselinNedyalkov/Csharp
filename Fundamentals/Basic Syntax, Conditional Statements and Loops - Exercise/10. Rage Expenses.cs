using System;
using System.Collections.Generic;
using System.Drawing;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            double lostGame = double.Parse(Console.ReadLine());
            double headSetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            //Every second lost game, Petar trashes his headset.
            //Every third lost game, Petar trashes his mouse.
            //When Petar trashes both his mouse and headset in the same lost game, he also trashes his keyboard.
            //Every second time, when he trashes his keyboard, he also trashes his display. 

            double headset = lostGame / 2;
            double mouse = lostGame / 3;
            double keyboard = lostGame / 6;
            double display = keyboard / 2;

            double ragePrice = Math.Floor(headset) * headSetPrice + Math.Floor(mouse) * mousePrice + Math.Floor(keyboard) * keyboardPrice + Math.Floor(display) * displayPrice;

            Console.WriteLine($"Rage expenses: {ragePrice:f2} lv.");
        }
    }
}
