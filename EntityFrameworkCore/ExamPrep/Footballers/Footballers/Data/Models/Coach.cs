using Footballers.Common;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models;
public class Coach
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.CoachNameMaxLength)]
    public string Name { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public virtual ICollection<Footballer> Footballers { get; set; } = new HashSet<Footballer>();
}
