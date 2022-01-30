using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] buskInfo = Console.ReadLine().Split();

            double carFuel = double.Parse(carInfo[1]);
            double carConsumptio = double.Parse(carInfo[2]);
            double carTankCap = double.Parse(carInfo[3]);
            
            double truckFuel = double.Parse(truckInfo[1]);
            double truckConsumptio = double.Parse(truckInfo[2]);
            double truckTankCap = double.Parse(truckInfo[3]);
            
            double busFuel = double.Parse(buskInfo[1]);
            double busConsumptio = double.Parse(buskInfo[2]);
            double busTankCap = double.Parse(buskInfo[3]);



            IVehical car = new Car(carFuel, carConsumptio, carTankCap);
            IVehical truck = new Truck(truckFuel, truckConsumptio, truckTankCap);
            IVehical bus = new Bus(busFuel, busConsumptio, busTankCap);

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] comands = Console.ReadLine().Split();
                string cmd = comands[0];
                string vehical = comands[1];
                double value = double.Parse(comands[2]);
               
                switch (cmd)
                {
                    case "Drive":
                        if (vehical == "Car")
                        {
                            if (car.EnoughtFuel(value))
                            {
                                car.Drive(value);
                                Console.WriteLine($"Car travelled {value} km");
                            }
                            else
                                Console.WriteLine("Car needs refueling");
                        }
                        else if(vehical == "Truck")
                        {
                            if (truck.EnoughtFuel(value))
                            {
                                truck.Drive(value);
                                Console.WriteLine($"Truck travelled {value} km");
                            }
                            else
                                Console.WriteLine("Truck needs refueling");
                        }
                        else if (vehical == "Bus")
                        {
                            if (bus.EnoughtFuel(value))
                            {
                                bus.IsEmpty = false;
                                bus.Drive(value);
                                Console.WriteLine($"Bus travelled {value} km");
                            }
                            else
                                Console.WriteLine("Bus needs refueling");
                        }
                        break;

                    case "Refuel":
                        try
                        {
                            if (vehical == "Car")
                            {
                                car.Refiling(value);
                            }
                            else if (vehical == "Truck")
                            {
                                truck.Refiling(value);
                            }
                            else if (vehical == "Bus")
                            {
                                bus.Refiling(value);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "DriveEmpty":
                        if (bus.EnoughtFuel(value))
                        {
                            bus.IsEmpty = true;
                            bus.Drive(value);
                            Console.WriteLine($"Bus travelled {value} km");
                        }
                        else
                            Console.WriteLine("Bus needs refueling");
                        break;

                    default:
                        break;
                }

            }//for

            Console.WriteLine($"Car: {car.FuelQuntity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuntity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuntity:f2}");
        }
    }
}
