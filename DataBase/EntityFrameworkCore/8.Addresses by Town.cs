using Microsoft.EntityFrameworkCore;
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

            string answer = GetAddressesByTown(dbContext);

            Console.WriteLine(answer);
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var adressesByTown = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    NumberEmployees = a.Employees.Count,
                    TownName = a.Town.Name,
                    a.AddressText
                })
                .Take(10)
                .ToArray();

            foreach (var ad in adressesByTown)
            {
                sb.AppendLine($"{ad.AddressText}, {ad.TownName} - {ad.NumberEmployees} employees");
            }   
               return sb.ToString().TrimEnd();
        }
    }
}
