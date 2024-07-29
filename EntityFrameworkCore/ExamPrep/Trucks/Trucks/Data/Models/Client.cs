using System.ComponentModel.DataAnnotations;
using Trucks.Common;

namespace Trucks.Data.Models;
public class Client
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(TableConstraints.ClientNationalityMaxLength)]
    public string Nationality { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ICollection<ClientTruck> ClientsTrucks { get; set; } = new HashSet<ClientTruck>();
}
