using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();
            List<Truck> TruckList = new List<Truck>();

            string[] inputData = Console.ReadLine().Split("/");

            while (inputData[0] != "end")
            {
                switch (inputData[0])
                {
                    case "Car":
                        string brand = inputData[1];
                        string model = inputData[2];
                        int hp = int.Parse(inputData[3]);

                        Car car = new Car(brand, model, hp);
                        carList.Add(car);
                        break;

                    case "Truck":
                        string brandT = inputData[1];
                        string modelT = inputData[2];
                        int weight = int.Parse(inputData[3]);

                        Truck truck = new Truck(brandT, modelT, weight);
                        TruckList.Add(truck);
                        break;

                    default:
                        break;
                }//swithc
                inputData = Console.ReadLine().Split("/");
            }//while
            Catalog catalog = new Catalog(carList, TruckList);

            if (catalog.Cars.Count() != 0)
            {
                List<Car> catalogUpdatedCar = catalog.Cars.OrderBy(x => x.Brand).ToList();
                Console.WriteLine("Cars:");
                foreach (var item in catalogUpdatedCar)
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.Hp}hp");
                }
            }
            if (catalog.Trucks.Count() != 0)
            {
                List<Truck> catalogUpdatedTruck = catalog.Trucks.OrderBy(x => x.Brand).ToList(); 
                Console.WriteLine("Trucks:");
                foreach (var itemT in catalog.Trucks)
                {
                    Console.WriteLine($"{itemT.Brand}: {itemT.Model} - {itemT.Weight}kg");
                }
            }
         
        }
    }//class program

    class Car
    {
        public Car(string brand, string model , int hp)
        {
            this.Brand = brand;
            this.Model = model;
            this.Hp = hp;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Hp { get; set; }
    }//class Car

    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

    }//class Truck

    class Catalog
    {
        public Catalog(List<Car> cars, List<Truck> trucks)
        {
            this.Cars = cars;
            this.Trucks = trucks;
        }

        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }//class Catalog
}
