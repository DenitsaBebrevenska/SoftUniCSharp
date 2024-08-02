using Footballers.Common;
using Footballers.DataProcessor.ExportDto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace Footballers.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coachesAndFootballers = context.Coaches
                .AsNoTracking()
                .Where(c => c.Footballers.Any())
                .Select(c => new ExportCoachDto()
                {
                    FootballersCount = c.Footballers.Count,
                    Name = c.Name,
                    Footballers = c.Footballers
                        .Select(f => new ExportFootballerDto()
                        {
                            Name = f.Name,
                            Position = f.PositionType.ToString()
                        })
                        .OrderBy(f => f.Name)
                        .ToArray()

                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.Name)
                .ToArray();

            string rootName = "Coaches";
            return XmlHelper.Serialize(coachesAndFootballers, rootName);
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamAndFootballers = context.Teams
                .ToArray()
                .Where(t => t.TeamsFootballers
                    .Any(tf => tf.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(tf => tf.Footballer.ContractStartDate >= date)
                        .OrderByDescending(ft => ft.Footballer.ContractEndDate)
                        .ThenBy(ft => ft.Footballer.Name)
                        .Select(tf => new
                        {
                            FootballerName = tf.Footballer.Name,
                            ContractStartDate =
                                tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = tf.Footballer.BestSkillType.ToString(),
                            PositionType = tf.Footballer.PositionType.ToString()
                        })

                        .ToArray()
                })
                .OrderByDescending(t => t.Footballers.Length)
                .ThenBy(t => t.Name)
                .Take(5);

            return JsonConvert.SerializeObject(teamAndFootballers, Formatting.Indented);
        }
    }
}
