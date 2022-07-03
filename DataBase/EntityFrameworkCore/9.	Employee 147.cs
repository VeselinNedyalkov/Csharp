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

            string answer = GetEmployee147(dbContext);

            Console.WriteLine(answer);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeeN = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FName = e.FirstName,
                    LName = e.LastName,
                    JTitle = e.JobTitle,
                    Projects = e.EmployeesProjects
                    .Select(p => new
                    {
                        ProjectName = p.Project.Name
                    })
                    .OrderBy(x => x.ProjectName)
                    .ToArray()
                })
                .ToArray();

            foreach (var ad in employeeN)
            {
                sb.AppendLine($"{ad.FName} {ad.LName} - {ad.JTitle}");

                foreach (var item in ad.Projects)
                {
                    sb.AppendLine($"{item.ProjectName}");
                }
            }   
               return sb.ToString().TrimEnd();
        }
    }
}
