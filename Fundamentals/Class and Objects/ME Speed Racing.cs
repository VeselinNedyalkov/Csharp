using System;
using System.Linq;
using System.Collections.Generic;

namespace Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberCars = int.Parse(Console.ReadLine());
            List<Cars> cars = new List<Cars>();

            for (int i = 0; i < numberCars; i++)
            {
                string[] inputInfo = Console.ReadLine().Split(' ');
                string model = inputInfo[0];
                double fuel = double.Parse(inputInfo[1]);
                double fuelPerKm = double.Parse(inputInfo[2]);
                cars.Add(new Cars(model, fuel, fuelPerKm, 0));
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] drive = cmd.Split();
                string carMode = drive[1];
                int distance = int.Parse(drive[2]);

                Cars currentCar = cars.Single(x => x.Model == carMode);

                if (currentCar.IsFuelEnought(distance, currentCar.FuelPerKm, currentCar.Fuel))
                {
                    currentCar.Fuel -= distance * currentCar.FuelPerKm;
                    currentCar.TravelDistance += distance;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.Fuel:f2} {car.TravelDistance}");
            }
        }
    }

    class Cars
    {
        public string Model { get; set; }
        public double Fuel { get; set; }
        public double FuelPerKm { get; set; }
        public int TravelDistance { get; set; }

        public Cars(string model, double fuel, double consumption, int distance)
        {
            Model = model;
            Fuel = fuel;
            FuelPerKm = consumption;
            TravelDistance = distance;
        }

        public bool IsFuelEnought(int distance, double fuelPerKm, double fuel)
        {
            bool canMove = false;
            if ((distance * fuelPerKm) <= fuel)
            {
                canMove = true;
            }

            return canMove;
        }
    }
}
