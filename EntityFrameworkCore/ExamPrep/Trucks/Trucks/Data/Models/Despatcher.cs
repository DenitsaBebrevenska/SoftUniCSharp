using System.ComponentModel.DataAnnotations;
using Trucks.Common;

namespace Trucks.Data.Models;
public class Despatcher
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.DespatcherNameMaxLength)]
    public string Name { get; set; } = null!;

    public string Position { get; set; }

    public virtual ICollection<Truck> Trucks { get; set; } = new HashSet<Truck>();
}
