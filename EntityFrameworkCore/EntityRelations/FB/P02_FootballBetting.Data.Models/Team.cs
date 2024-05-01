using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;
public class Team
{
    public int TeamId { get; set; }

    [MaxLength(ValidationConstraints.TeamNameLength)]
    public string Name { get; set; }

    [MaxLength(ValidationConstraints.TeamUrlLogoLength)]
    public string LogoUrl { get; set; }

    [MaxLength(ValidationConstraints.TeamInitialsLength)]
    public string Initials { get; set; }
    public decimal Budget { get; set; }
    public string PrimaryKitColorId { get; set; }
    public string SecondaryKitColorId { get; set; }
    public int TownId { get; set; }
}
