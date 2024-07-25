using Boardgames.Common;
using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models;
public class Boardgame
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.BoardgameNameMaxLength)]
    public string Name { get; set; } = null!;

    public double Rating { get; set; }

    public int YearPublished { get; set; }

    public CategoryType CategoryType { get; set; }

    public string Mechanics { get; set; } = null!;

    public int CreatorId { get; set; }

    public virtual Creator Creator { get; set; } = null!;

    public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = new HashSet<BoardgameSeller>();
}
