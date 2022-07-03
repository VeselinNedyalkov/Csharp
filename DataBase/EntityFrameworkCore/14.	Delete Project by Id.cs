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

            Project projTodelete = context
                .Projects
                .Find(2);

            var referensEmplo = context.EmployeesProjects
                .Where(e => e.ProjectId == projTodelete.ProjectId)
                .ToArray();

            context.EmployeesProjects.RemoveRange(referensEmplo);
            context.Projects.Remove(projTodelete);
            context.SaveChanges();

            var projectNames = context
                .Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            foreach (var p in projectNames)
            {
                sb.AppendLine($"{p}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
