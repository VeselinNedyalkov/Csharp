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

            string answer = GetEmployeesFromResearchAndDevelopment(dbContext);

            Console.WriteLine(answer);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var answer = context.Employees
                 .Where(e => e.Department.Name == "Research and Development")
                 .Select(e => new
                 {
                     e.FirstName,
                     e.LastName,
                     DepartmentName = e.Department.Name,
                     e.Salary
                 })
                 .OrderBy(e => e.Salary)
                 .ThenByDescending(e => e.FirstName)
                 .ToArray();

            foreach (var e in answer)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
