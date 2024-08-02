using Footballers.Common;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models;
public class Team
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.TeamNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(TableConstraints.TeamNationalityMaxLength)]
    public string Nationality { get; set; } = null!;

    public int Trophies { get; set; }

    public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; } = new HashSet<TeamFootballer>();
}
