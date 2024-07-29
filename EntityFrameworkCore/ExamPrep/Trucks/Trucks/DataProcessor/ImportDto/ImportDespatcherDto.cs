using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Common;

namespace Trucks.DataProcessor.ImportDto;

[XmlType("Despatcher")]
public class ImportDespatcherDto
{
    [Required]
    [XmlElement("Name")]
    [StringLength(TableConstraints.DespatcherNameMaxLength, MinimumLength = TableConstraints.DespatcherNameMinLength)]
    public string Name { get; set; } = null!;

    [XmlElement("Position")]
    public string Position { get; set; }

    [XmlArray("Trucks")]
    public ImportTruckDto[] Trucks { get; set; }

}
