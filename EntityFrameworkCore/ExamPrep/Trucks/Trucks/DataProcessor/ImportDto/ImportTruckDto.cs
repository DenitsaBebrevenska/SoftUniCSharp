using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Common;

namespace Trucks.DataProcessor.ImportDto;

[XmlType("Truck")]
public class ImportTruckDto
{
    [Required]
    [XmlElement("RegistrationNumber")]
    [StringLength(TableConstraints.TruckRegistrationNumberLength)]
    [RegularExpression(@"[A-Z]{2}\d{4}[A-Z]{2}")]
    public string RegistrationNumber { get; set; } = null!;

    [Required]
    [XmlElement("VinNumber")]
    [StringLength(TableConstraints.TruckVinLength)]
    public string VinNumber { get; set; } = null!;

    [Required]
    [Range(TableConstraints.TruckTankMinCapacity, TableConstraints.TruckTankMaxCapacity)]
    public int TankCapacity { get; set; }

    [Required]
    [Range(TableConstraints.TruckCargoMinCapacity, TableConstraints.TruckCargoMaxCapacity)]
    public int CargoCapacity { get; set; }

    [Required]
    public int CategoryType { get; set; }

    [Required]
    public int MakeType { get; set; }

}
