using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Common;
public class Team
{
    public int TeamId { get; set; }

    [MaxLength()]
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public string Initials { get; set; }
    public decimal Budget { get; set; }
    public string PrimaryKitColorId { get; set; }
    public string SecondaryKitColorId { get; set; }
    public int TownId { get; set; }
}
