using System;
using System.Diagnostics;
 
namespace _01._Programming_Fundamentals_Mid_Exam_Retake
{
    class Program
    {
        static void Main(string[] args)
        {
            string partsPrice = Console.ReadLine();
            double totalPrice = 0;
 
            while (partsPrice != "special" && partsPrice != "regular")
            {
                double partsPriceNum = double.Parse(partsPrice);
 
                if (partsPriceNum <= 0)
                {
                    Console.WriteLine("Invalid price!");        
                }
                else
                {
                    totalPrice += partsPriceNum;       
                }
                partsPrice = Console.ReadLine();
            }
            double totalPriceWithoutTaxes = totalPrice;
 
            double taxes = totalPrice * 0.2;
            totalPrice += taxes;
 
 
 
            if (partsPrice == "special")
            {
                totalPrice -= totalPrice * 0.1;
            }
 
            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine($"Congratulations you've just bought a new computer!" +
                    $"\nPrice without taxes: {totalPriceWithoutTaxes:F2}$" +
                    $"\nTaxes: {taxes:f2}$" +
                    $"\n-----------" +
                    $"\nTotal price: {totalPrice:f2}$");
            }
        }
    }
}
