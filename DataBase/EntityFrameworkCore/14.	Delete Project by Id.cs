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

            string answer = GetEmployeesByFirstNameStartingWithSa(dbContext);

            Console.WriteLine(answer);
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var findEmployee = context.Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();


            foreach (var s in findEmployee)
            {
                sb.AppendLine($"{s.FirstName} {s.LastName} - {s.JobTitle} - (${s.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
