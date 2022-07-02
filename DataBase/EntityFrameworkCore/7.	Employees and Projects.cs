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

            string answer = GetEmployeesInPeriod(dbContext);

            Console.WriteLine(answer);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var emplyesAndProjects = context.Employees
                 .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001
                 && p.Project.StartDate.Year <= 2003))
                 .Take(10)
                 .Select(e => new
                 {
                     e.FirstName,
                     e.LastName,
                     ManagerFName = e.Manager.FirstName,
                     ManagerLName = e.Manager.LastName,
                     AllProjects = e.EmployeesProjects
                     .Select(ep => new
                     {
                         ProjectName = ep.Project.Name,
                         StartDate = ep.Project.StartDate
                         .ToString("M/d/yyyy h:mm:ss tt"),
                         EndDate = ep.Project.EndDate.HasValue
                         ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                         : "not finished"
                     }).ToArray()
                 })
                 .ToArray();

            foreach (var emp in emplyesAndProjects)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.ManagerFName} {emp.ManagerLName}");

                foreach (var pro in emp.AllProjects)
                {
                    sb.AppendLine($"--{pro.ProjectName} - {pro.StartDate} - {pro.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
