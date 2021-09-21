using System;
using System.Diagnostics;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double numPeople = int.Parse(Console.ReadLine());
            string typeGrpup = Console.ReadLine();
            string dayWeek = Console.ReadLine();
            double totalPrice = 0;
            double price = 0;

            switch (typeGrpup)
            {
                case "Students":
                    if (dayWeek == "Friday")
                    {
                        totalPrice = numPeople * 8.45;
                    }
                    else if (dayWeek == "Saturday")
                    {
                        totalPrice = numPeople * 9.80;
                    }
                    else if (dayWeek == "Sunday")
                    {
                        totalPrice = numPeople * 10.46;
                    }
                    if (numPeople >= 30)
                    {
                        totalPrice -= totalPrice * 0.15;
                    }
                    break;
                case "Business":
                    if (dayWeek == "Friday")
                    {
                        price = 10.9;
                        totalPrice = numPeople * price;
                    }
                    else if (dayWeek == "Saturday")
                    {
                        price = 15.6;
                        totalPrice = numPeople * price;
                    }
                    else if (dayWeek == "Sunday")
                    {
                        price = 16;
                        totalPrice = numPeople * price;
                    }
                    if (numPeople >= 100)
                    {
                        totalPrice -= 10 * price;
                    }
                    break;
                case "Regular":
                    if (dayWeek == "Friday")
                    {
                        totalPrice = numPeople * 15;
                    }
                    else if (dayWeek == "Saturday")
                    {
                        totalPrice = numPeople * 20;
                    }
                    else if (dayWeek == "Sunday")
                    {
                        totalPrice = numPeople * 22.5;
                    }
                    if (numPeople >= 10 && numPeople <= 20)
                    {
                        totalPrice -= totalPrice * 0.05;
                    }
                    break;               
            }//switch

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
