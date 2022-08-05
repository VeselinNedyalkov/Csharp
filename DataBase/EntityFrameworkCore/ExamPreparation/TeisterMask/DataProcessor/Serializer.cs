namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Microsoft.VisualBasic;
    using Newtonsoft.Json;
using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {

            var projectExport = context.Projects
                .Where(x => x.Tasks.Any())
                .ToArray()
                .Select(pr => new ProjectExportModel
                {
                    TasksCount = pr.Tasks.Count,
                    ProjectName = pr.Name,
                    HasEndDate = pr.DueDate == null ? "No" : "Yes",
                    Tasks = pr.Tasks.Select(tsk => new TaskExportModel
                    {
                        Name = tsk.Name,
                        Label = tsk.LabelType.ToString(),
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            var exportXml = XmlConverter.Serialize(projectExport, "Projects");
                
            return exportXml;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesTasks.Any(z => z.Task.OpenDate >= date))
                .ToArray()
                .Select(emp => new
                {
                    Username = emp.Username,
                    Tasks = emp.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date)
                    .ToArray()
                    .Select(t => new
                    {
                        TaskName = t.Task.Name,
                        OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.Task.LabelType.ToString(),
                        ExecutionType = t.Task.ExecutionType.ToString()
                    })
                    .OrderByDescending(x => DateTime.Parse(x.DueDate))
                    .ThenBy(x => x.TaskName)
                    .ToArray()
                })
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return jsonResult;
        }
    }
}