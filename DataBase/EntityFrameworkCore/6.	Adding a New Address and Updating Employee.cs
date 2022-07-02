using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using SoftUniContext dbContext = new SoftUniContext();

            string answer = AddNewAddressToEmployee(dbContext);

            Console.WriteLine(answer);
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            Employee nakov = context.Employees.First(e => e.LastName == "Nakov");

            nakov.Address = newAddress;

            context.SaveChanges();

            var adress = context.Employees.OrderByDescending(e => e.AddressId)
                .Take(10).Select(e => e.Address.AddressText).ToArray();

            foreach (var adr in adress)
            {
                sb.AppendLine($"{adr}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
