using System;
using System.Linq;
using System.Collections.Generic;

namespace Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cars> cars = new List<Cars>();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] inputCars = Console.ReadLine().Split("|");
                string carName = inputCars[0];
                int miles = int.Parse(inputCars[1]);
                int fuel = int.Parse(inputCars[2]);
                //fill the List with the objects
                cars.Add(new Cars(carName, miles, fuel));
            }


            string cmd;
            while ((cmd = Console.ReadLine()) != "Stop")
            {
                string[] data = cmd.Split(" : ");

                switch (data[0])
                {
                    case "Drive":
                        string car = data[1];
                        int distance = int.Parse(data[2]);
                        int fuel = int.Parse(data[3]);
                        const int MILES_SELL = 100000;
                        //check if we have enought fuel 
                        if (cars.Single(x => x.CarName == car).Fuel < fuel)                       
                            Console.WriteLine("Not enough fuel to make that ride");
                        else
                        {
                            //add the distance and remuve the fuel from the car
                            cars.Single(x => x.CarName == car).Miles += distance;
                            cars.Single(x => x.CarName == car).Fuel -= fuel;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        }
                        //if distance is more than 100 000 we sell the car
                        if(cars.Single(x => x.CarName == car).Miles >= MILES_SELL)
                        {
                            Console.WriteLine($"Time to sell the {car}!");
                            cars.Remove(cars.Single(x => x.CarName == car));
                        }

                        break;

                    case "Refuel":
                        car = data[1];
                        fuel = int.Parse(data[2]);
                        const int MAX_FUEL = 75;
                        //check if we can fill the tank
                        if ((cars.Single(x => x.CarName == car).Fuel + fuel) > MAX_FUEL)
                        {
                            //if the fuel is more than max cap 
                            Console.WriteLine($"{car} refueled with {MAX_FUEL - cars.Single(x => x.CarName == car).Fuel} liters");
                            cars.Single(x => x.CarName == car).Fuel = MAX_FUEL;                           
                        }                           
                        else
                        {
                            //if we can take all the fuel
                            cars.Single(x => x.CarName == car).Fuel += fuel;
                            Console.WriteLine($"{car} refueled with {fuel} liters");
                        }                            
                        break;

                    case "Revert":
                        car = data[1];
                        int miles = int.Parse(data[2]);
                        const int MIN_MILES = 10000;
                        //check afther reverting if the miles are less than 10 000
                        if ((cars.Single(x => x.CarName == car).Miles - miles) >= MIN_MILES)
                        {
                            //if - miles is more than 10 000 we just - them
                            cars.Single(x => x.CarName == car).Miles -= miles;
                            Console.WriteLine($"{car} mileage decreased by {miles} kilometers");
                        }
                        else
                        {
                            //if miles are less than 10 000 we make them equal to 10 000
                            cars.Single(x => x.CarName == car).Miles = MIN_MILES;
                        }
                        break;

                    default:
                        break;
                }
            }//while


            //sort and print
            foreach (var car in cars.OrderByDescending(x => x.Miles).ThenBy(x => x.CarName))
            {
                Console.WriteLine($"{car.CarName} -> Mileage: {car.Miles} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }

        class Cars
        {
            public string CarName { get; set; }
            public int Miles { get; set; }

            public int Fuel { get; set; }

            public Cars(string name, int miles , int fuel)
            {
                CarName = name;
                Miles = miles;
                Fuel = fuel;
            }
        }
    }
}
