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
            SoftUniContext dbContext = new SoftUniContext();

            string answer = GetEmployeesWithSalaryOver50000(dbContext);

            Console.WriteLine(answer);
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

           var allEmployees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                { 
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .ToArray()
                .OrderBy(e => e.FirstName);

            foreach (var e in allEmployees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
