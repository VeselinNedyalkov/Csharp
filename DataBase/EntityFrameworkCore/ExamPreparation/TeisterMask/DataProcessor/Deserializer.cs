namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            List<Project> projects = new List<Project>();

            var projectImport = XmlConverter.Deserializer<ProjectsImportModel>(xmlString, "Projects");

            foreach (var pr in projectImport)
            {
                var validateOpenDate = DateTime.TryParseExact(pr.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                  DateTimeStyles.None,
                  out DateTime releaseDatea);

                if (!IsValid(pr) || !validateOpenDate)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var validDueDate = DateTime.TryParseExact(pr.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releaseDate);

                Project project = new Project
                {
                    Name = pr.Name,
                    OpenDate = DateTime.ParseExact(pr.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DueDate = validDueDate ? DateTime.ParseExact(pr.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null,
                    Tasks = new List<Task>()
                };

                foreach (var tas in pr.Tasks)
                {
                    var taskOpenDate = DateTime.ParseExact(tas.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(tas.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (!IsValid(tas))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    if (project.OpenDate > taskOpenDate || taskDueDate > project.DueDate)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }


                    Task task = new Task
                    {
                        Name = tas.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)tas.ExecutionType,
                        LabelType = (LabelType)tas.LabelType
                    };

                    project.Tasks.Add(task);

                }

                projects.Add(project);
                sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
            }

            context.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<Employee> employees = new List<Employee>();

            var jsonInput = JsonConvert.DeserializeObject<IEnumerable<EmployeesImportModel>>(jsonString);


            foreach (var empl in jsonInput)
            {
                if (!IsValid(empl))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Employee employee = new Employee
                {
                    Username = empl.Username,
                    Email = empl.Email,
                    Phone = empl.Phone,
                    EmployeesTasks = new HashSet<EmployeeTask>()
                };

                foreach (var taskId in empl.Tasks.Distinct())
                {
                    var task = context.Tasks.Find(taskId);
                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var currEmployeeTask = new EmployeeTask
                    {
                        Employee = employee,
                        Task = task,
                    };

                    employee.EmployeesTasks.Add(currEmployeeTask);
                }

                employees.Add(employee);
                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count} tasks.");
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}