using System;
using System.Linq;
using System.Collections.Generic;

namespace Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int numberInformation = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInformation; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                string model = inputData[0];
                int engineSpeed = int.Parse(inputData[1]);
                int enginePower = int.Parse(inputData[2]);
                int cargoWeight = int.Parse(inputData[3]);
                string cargoTypr = inputData[4];
                //we create class Car and send all the data
                cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargoTypr));
            }


            string sort = Console.ReadLine();

            switch (sort)
            {
                case "fragile":
                    //if car where class Cargo wejght is less thank 1000
                    foreach (var car in cars.Where(x => x.Cargos.CargoWeight < 1000))
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                    break;

                case "flamable":
                    //if car where class cargo type is flamable AND class engine power is more than 250
                    foreach (var car in cars.Where(x => x.Cargos.CargoType == "flamable" && x.Engines.EnginePower > 250))
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                    break;

                default:
                    break;
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine Engines { get; set; }
        public Cargo Cargos { get; set; }

        public Car(string model,int engineSpeed ,int enginePower,int cargoWeight,string cargoType )
        {
            Model = model;
            //we add other classes to the class Car all data is coming from main
            Engines = new Engine(engineSpeed, enginePower);
            Cargos = new Cargo(cargoWeight, cargoType);
        }
        

    }
    class Engine
    {
        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }

        public Engine(int engineSPeed , int enginePower)
        {
            EngineSpeed = engineSPeed;

            EnginePower = enginePower;
        }
    }

    class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }

        public Cargo(int cargoWeight, string cargoType)
        {
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }
    }
}

