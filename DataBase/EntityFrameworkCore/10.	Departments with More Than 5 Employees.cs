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

            string answer = GetDepartmentsWithMoreThan5Employees(dbContext);

            Console.WriteLine(answer);
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departmentMoreThanFive = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepName = d.Name,
                    ManaFirstName = d.Manager.FirstName,
                    ManaLastName = d.Manager.LastName,
                    Employees = d.Employees
                    .Select(e => new
                    {
                        EmplFirstName = e.FirstName,
                        EmplLastName = e.LastName,
                        EmpJobTitle = e.JobTitle
                    })
                    .OrderBy(e => e.EmplFirstName)
                    .ThenBy(e => e.EmplLastName)
                    .ToArray()
                })
                .ToArray();

            foreach (var d in departmentMoreThanFive)
            {
                sb.AppendLine($"{d.DepName} - {d.ManaFirstName}  {d.ManaLastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.EmplFirstName} {e.EmplLastName} - {e.EmpJobTitle}");
                }
            }   
               return sb.ToString().TrimEnd();
        }
    }
}
