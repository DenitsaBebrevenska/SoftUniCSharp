using Cadastre.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("Property")]
public class ImportPropertyDto
{
    [XmlElement("PropertyIdentifier")]
    [Range(TableConstraints.PropertyIdentifierMinLength, TableConstraints.PropertyIdentifierMaxLength)]
    [Required]
    public string PropertyIdentifier { get; set; } = null!;

    [XmlElement("Area")]
    [Range(TableConstraints.PropertyAreaMinValue, TableConstraints.PropertyAreaMaxValue)]
    [Required]
    public int Area { get; set; }

    [XmlElement("Details")]
    [Range(TableConstraints.PropertyDetailsMinLength, TableConstraints.PropertyDetailsMaxLength)]
    public string? Details { get; set; }

    [XmlElement("Address")]
    [Range(TableConstraints.PropertyAddressMinLength, TableConstraints.PropertyAddressMaxLength)]
    [Required]
    public string Address { get; set; } = null!;

    [XmlElement("DateOfAcquisition")]
    [Required]
    public string DateOfAcquisition { get; set; } = null!;
}
