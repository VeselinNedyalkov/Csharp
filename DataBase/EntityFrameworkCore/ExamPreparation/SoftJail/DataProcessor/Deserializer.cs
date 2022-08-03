namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using SoftJail.Data.Models;
    using System.Xml.Linq;
    using System.Globalization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<DepartmentsCellsImportModel> departmentsCells =
                JsonConvert.DeserializeObject<IEnumerable<DepartmentsCellsImportModel>>
                 (jsonString);

            List<Department> departments = new List<Department>();

            foreach (var dep in departmentsCells)
            {
                if (!IsValid(dep) || !dep.Cells.Any() || !dep.Cells.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department
                {
                    Name = dep.Name,
                    Cells = dep.Cells.Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    })
                    .ToList()
                };

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                departments.Add(department);
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Prisoner> prisoners = new List<Prisoner>();

            var prisonersInput = JsonConvert.DeserializeObject<IEnumerable<PrisonersMailsImportModel>>(jsonString);

            foreach (var item in prisonersInput)
            {
                if (!IsValid(item) || !item.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var IsRealeasedateValid = DateTime.TryParseExact(
                    item.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releaseDate);

                Prisoner prisoner = new Prisoner
                {
                    FullName = item.FullName,
                    Nickname = item.Nickname,
                    Age = item.Age,
                    Bail = item.Bail,
                    CellId = item.CellId,
                    IncarcerationDate = DateTime.ParseExact(item.IncarcerationDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = IsRealeasedateValid ? releaseDate : (DateTime?)null,
                    Mails = item.Mails.Select(m => new Mail
                    {
                        Sender = m.Sender,
                        Address = m.Address,
                        Description = m.Description
                    })
                    .ToList()
                };

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");

            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var officersImport = XmlConverter
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}