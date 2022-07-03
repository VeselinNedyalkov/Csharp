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

            string answer = GetLatestProjects(dbContext);

            Console.WriteLine(answer);
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderBy(p => p.Name)
                .Take(10)
                .Select(p => new
                {
                    Name = p.Name,
                    Descroption = p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                })
                .ToArray();

            foreach (var d in projects)
            {
                sb.AppendLine(d.Name);
                sb.AppendLine(d.Descroption);
                sb.AppendLine(d.StartDate);
            }   
               return sb.ToString().TrimEnd();
        }
    }
}
