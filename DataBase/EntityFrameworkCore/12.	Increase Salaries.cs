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

            string answer = IncreaseSalaries(dbContext);

            Console.WriteLine(answer);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var salaries = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .ToList()
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            

            foreach (var s in salaries)
            {
                s.Salary *= 1.12M;
                sb.AppendLine($"{s.FirstName} {s.LastName} (${s.Salary:f2})");
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
    }
}
