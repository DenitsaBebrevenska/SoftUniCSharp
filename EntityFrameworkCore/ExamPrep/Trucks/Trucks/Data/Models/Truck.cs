using System.ComponentModel.DataAnnotations;
using Trucks.Common;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models;
public class Truck
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.TruckRegistrationNumberLength)]
    public string RegistrationNumber { get; set; } = null!;

    [MaxLength(TableConstraints.TruckVinLength)]
    public string VinNumber { get; set; } = null!;

    [MaxLength(TableConstraints.TruckTankMaxCapacity)]
    public int TankCapacity { get; set; }

    [MaxLength(TableConstraints.TruckCargoMaxCapacity)]
    public int CargoCapacity { get; set; }

    public CategoryType CategoryType { get; set; }

    public MakeType MakeType { get; set; }

    public int DespatcherId { get; set; }

    public virtual Despatcher Despatcher { get; set; } = null!;

    public virtual ICollection<ClientTruck> ClientsTrucks { get; set; } = new HashSet<ClientTruck>();
}
