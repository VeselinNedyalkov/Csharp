namespace Footballers.DataProcessor
{
    using System;
using System.Globalization;
    using System.Linq;
    using Data;
using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coachesExport = context.Coaches
                .Where(x => x.Footballers.Any())
                .ToArray()
                .Select(x => new CoachesExportModel
                {
                    CoachName = x.Name,
                    FootballersCount = x.Footballers.Count(),
                    Footballers = x.Footballers.Select(f => new FootballerExportModel
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString()
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.FootballersCount)
                .ThenBy(x => x.CoachName)
                .ToArray();

            var xmlCoaches = XmlConverter.Serialize(coachesExport, "Coaches");

            return xmlCoaches;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamExport = context.Teams
                .Where(x => x.TeamsFootballers.Any(z => z.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(team => new
                {
                    Name = team.Name,
                    Footballers = team.TeamsFootballers
                    .Where(x => x.Footballer.ContractStartDate >= date)
                    .OrderByDescending(x => x.Footballer.ContractEndDate)
                    .ThenBy(x => x.Footballer.Name)
                    .Select(player => new
                    {
                        FootballerName = player.Footballer.Name,
                        ContractStartDate = player.Footballer.ContractStartDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        ContractEndDate = player.Footballer.ContractEndDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        BestSkillType = player.Footballer.BestSkillType.ToString(),
                        PositionType = player.Footballer.PositionType.ToString(),
                    })
                    .ToArray()
                })
                .OrderByDescending(x => x.Footballers.Count())
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();

            var jsonExport = JsonConvert.SerializeObject(teamExport , Formatting.Indented);

            return jsonExport;
        }
    }
}
