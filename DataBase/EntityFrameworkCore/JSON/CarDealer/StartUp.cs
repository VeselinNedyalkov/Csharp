using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Castle.Core.Resource;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            ////09. Import Suppliers
            //string suppliers = File.ReadAllText("../../../Datasets/Suppliers.json");
            //Console.WriteLine(ImportSuppliers(db, suppliers));

            ////10. Import Parts
            //string parts = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(db, parts));

            ////11.Import Cars
            //string cars = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(db, cars));

            //12. Import Customers
            //string customers = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(db, customers));

            //13. Import Sales
            //string sales = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(db, sales));

            //14. Export Ordered Customers
            //Console.WriteLine(GetOrderedCustomers(db));

            //15. Export Cars From Make Toyota
            //Console.WriteLine(GetCarsFromMakeToyota(db));

            //16. Export Local Suppliers
            //Console.WriteLine(GetLocalSuppliers(db));

            //17. Export Cars With Their List Of Parts
            //Console.WriteLine(GetCarsWithTheirListOfParts(db));

            //18. Export Total Sales By Customer
            //Console.WriteLine(GetTotalSalesByCustomer(db));

            //19. Export Sales With Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }

        private static void InitiazerMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();

        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitiazerMapper();

            var suppliers = JsonConvert.DeserializeObject<IEnumerable<SuppliersModel>>(inputJson);

            var users = mapper.Map<IEnumerable<Supplier>>(suppliers);

            context.Suppliers.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitiazerMapper();

            List<int> supllierId = context.Suppliers.Select(x => x.Id).ToList();

            var parts = JsonConvert.DeserializeObject<IEnumerable<PartsModel>>(inputJson)
                .Where(x => supllierId.Contains(x.SupplierId));

            var result = mapper.Map<IEnumerable<Part>>(parts);
            context.Parts.AddRange(result);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IEnumerable<CarsModel> dtoCars = JsonConvert.DeserializeObject<IEnumerable<CarsModel>>(inputJson);

            List<Car> cars = new List<Car>();

            foreach (CarsModel dtoCar in dtoCars)
            {
                Car newCar = new Car
                {
                    Make = dtoCar.Make,
                    Model = dtoCar.Model,
                    TravelledDistance = dtoCar.TravelledDistance,
                };
                foreach (int partId in dtoCar.PartsId.Distinct())
                {
                    newCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                cars.Add(newCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitiazerMapper();

            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomersModel>>(inputJson);

            var result = mapper.Map<IEnumerable<Customer>>(customers);
            context.Customers.AddRange(result);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitiazerMapper();
            var sales = JsonConvert.DeserializeObject<IEnumerable<SalesModel>>(inputJson);

            var result = mapper.Map<IEnumerable<Sale>>(sales);
            context.Sales.AddRange(result);
            context.SaveChanges();

            return $"Successfully imported {result.Count()}.";
        }

        //14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {

            var customers = context.Customers
            .OrderBy(x => x.BirthDate)
            .ThenBy(x => x.IsYoungDriver == true)
            .Select(x => new
            {
                x.Name,
                BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                x.IsYoungDriver
            })
            .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        //15. Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var selectedCars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .ToArray();

            return JsonConvert.SerializeObject(selectedCars, Formatting.Indented);
        }

        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suplliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToArray();

            return JsonConvert.SerializeObject(suplliers, Formatting.Indented);
        }

        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var result = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance
                    },
                    parts = x.PartCars.Select(y => new
                    {
                        y.Part.Name,
                        Price = y.Part.Price.ToString("F2")
                    })
                })
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        //18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithCar = context.Customers
                .Where(x => x.Sales.Count() > 0)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count(),
                    spentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(j => j.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenBy(x => x.boughtCars)
                .ToArray();

            return JsonConvert.SerializeObject(customersWithCar, Formatting.Indented);
        }

        //19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var carSales = context.Sales
                .Select(x => new
                {
                    car = new
                    {
                        x.Car.Make,
                        x.Car.Model,
                        x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(y => y.Part.Price).ToString("F2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price) - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100).ToString("F2")
                })
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(carSales, Formatting.Indented);
        }
    }
}