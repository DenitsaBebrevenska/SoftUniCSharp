using Boardgames.Common;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models;
public class Seller
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.SellerNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(TableConstraints.SellerAddressMaxLength)]
    public string Address { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Website { get; set; } = null!;

    public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = new HashSet<BoardgameSeller>();
}
