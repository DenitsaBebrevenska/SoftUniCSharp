using Cadastre.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("Property")]
public class ImportPropertyDto
{
    [XmlElement("PropertyIdentifier")]
    [StringLength(TableConstraints.PropertyIdentifierMaxLength, MinimumLength = TableConstraints.PropertyIdentifierMinLength)]
    [Required]
    public string PropertyIdentifier { get; set; } = null!;

    [XmlElement("Area")]
    [Range(TableConstraints.PropertyAreaMinValue, TableConstraints.PropertyAreaMaxValue)]
    [Required]
    public int Area { get; set; }

    [XmlElement("Details")]
    [StringLength(TableConstraints.PropertyDetailsMaxLength, MinimumLength = TableConstraints.PropertyDetailsMinLength)]
    public string? Details { get; set; }

    [XmlElement("Address")]
    [StringLength(TableConstraints.PropertyAddressMaxLength, MinimumLength = TableConstraints.PropertyAddressMinLength)]
    [Required]
    public string Address { get; set; } = null!;

    [XmlElement("DateOfAcquisition")]
    [Required]
    public string DateOfAcquisition { get; set; } = null!;
}
