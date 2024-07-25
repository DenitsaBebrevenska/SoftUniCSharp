using Boardgames.Common;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models;
public class Creator
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.CreatorFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [MaxLength(TableConstraints.CreatorLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    public virtual ICollection<Boardgame> Boardgames { get; set; } = new HashSet<Boardgame>();
}
