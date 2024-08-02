using Footballers.Common;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace Footballers.DataProcessor
{
    using Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            string rootName = "Coaches";
            var coachDtos = XmlHelper.Deserialize<ImportCoachDto[]>(xmlString, rootName);
            StringBuilder sb = new StringBuilder();
            var validCoaches = new HashSet<Coach>();

            int bestSkillMinValue = Enum.GetValues(typeof(BestSkillType))
                .Cast<int>()
                .Min();
            int bestSkillMaxValue = Enum.GetValues(typeof(BestSkillType))
                .Cast<int>()
                .Max();
            int positionTypeMinValue = Enum.GetValues(typeof(PositionType))
                .Cast<int>()
                .Min();
            int positionTypeMaxValue = Enum.GetValues(typeof(PositionType))
                .Cast<int>()
                .Max();

            foreach (var coachDto in coachDtos)
            {
                if (!IsValid(coachDto) ||
                    string.IsNullOrEmpty(coachDto.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality
                };


                foreach (var footballerDto in coachDto.Footballers)
                {

                    if (!IsValid(footballerDto) ||
                        !DateTime.TryParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDateResult) ||
                        !DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDateResult) ||
                        startDateResult > endDateResult ||
                        (footballerDto.BestSkillType > bestSkillMaxValue || footballerDto.BestSkillType < bestSkillMinValue) ||
                        (footballerDto.PositionType > positionTypeMaxValue || footballerDto.PositionType < positionTypeMinValue))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = startDateResult,
                        ContractEndDate = endDateResult,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        PositionType = (PositionType)footballerDto.PositionType,
                        Coach = coach
                    };

                    coach.Footballers.Add(footballer);
                }

                validCoaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            var validTeams = new HashSet<Team>();
            var existingFootballerIds = context.Footballers
                .Select(f => f.Id)
                .ToArray();

            foreach (var teamDto in teamDtos)
            {
                if (!IsValid(teamDto) ||
                    int.Parse(teamDto.Trophies) < TableConstraints.TeamMinimumTrophyCount)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = int.Parse(teamDto.Trophies)
                };

                foreach (var footballerId in teamDto.Footballers.Distinct())
                {
                    if (!existingFootballerIds.Contains(footballerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer()
                    {
                        FootballerId = footballerId,
                        Team = team
                    });
                }

                validTeams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeams);
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
