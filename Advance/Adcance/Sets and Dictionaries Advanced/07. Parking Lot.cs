using System;
using System.Collections.Generic;

namespace Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] dataCars = cmd.Split(", ");
                string inOut = dataCars[0];
                string carPlate = dataCars[1];

                switch (inOut)
                {
                    case "IN":
                        carNumbers.Add(carPlate);
                        break;

                    case "OUT":
                        carNumbers.Remove(carPlate);
                        break;

                    default:
                        break;
                }
            }

            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var number in carNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            
        }
    }
}







//Create a program that:
//•	Records a car number for every car that enters the parking lot
//•	Removes a car number when the car leaves the parking lot
//The input will be a string in the format: "direction, carNumber".
//You will be receiving commands until the "END" command is given.
//Print the car numbers of the cars, which are still in the parking lot:

