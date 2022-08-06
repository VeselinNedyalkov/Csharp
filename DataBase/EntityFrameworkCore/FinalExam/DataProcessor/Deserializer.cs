namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            List<Coach> coaches = new List<Coach>();

            var coachesImport = XmlConverter.Deserializer<CoachImportModel>(xmlString, "Coaches");

            foreach (var co in coachesImport)
            {
                if (!IsValid(co))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach
                {
                    Name = co.Name,
                    Nationality = co.Nationality
                };

                foreach (var f in co.Footballers)
                {
                    if (!IsValid(f))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validContractStartDate = DateTime.TryParseExact(f.ContractStartDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime releaseDate);

                    var validContractEndDate = DateTime.TryParseExact(f.ContractEndDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime endDate);

                    if (!validContractStartDate || !validContractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var StartDate = DateTime.ParseExact(f.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var EndDate = DateTime.ParseExact(f.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (StartDate > EndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer
                    {
                        Name = f.Name,
                        ContractStartDate = StartDate,
                        ContractEndDate = EndDate,
                        BestSkillType = (BestSkillType)f.BestSkillType,
                        PositionType = (PositionType)f.PositionType
                    };

                    coach.Footballers.Add(footballer);
                }

                coaches.Add(coach);
                sb.AppendLine(String.Format(SuccessfullyImportedCoach,
                    coach.Name , coach.Footballers.Count));
            }

            context.AddRange(coaches);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Team> teams = new List<Team>();

            var teamsImport = JsonConvert.DeserializeObject<IEnumerable<TeamsImportModel>>(jsonString);

            foreach (var t in teamsImport)
            {
                if (!IsValid(t))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team
                {
                    Name = t.Name,
                    Nationality = t.Nationality,
                    Trophies = t.Trophies,
                };

                var uniqueFootbalers = t.Footballers.Distinct();

                foreach (var player in uniqueFootbalers)
                {
                    var unique = context.Footballers.FirstOrDefault(x => x.Id == player);

                    if (unique == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer teamFoot = new TeamFootballer
                    {
                        Team = team,
                        Footballer = unique
                    };

                    team.TeamsFootballers.Add(teamFoot);
                }

                teams.Add(team);
                sb.AppendLine(String.Format(SuccessfullyImportedTeam,
                    team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(teams);
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
