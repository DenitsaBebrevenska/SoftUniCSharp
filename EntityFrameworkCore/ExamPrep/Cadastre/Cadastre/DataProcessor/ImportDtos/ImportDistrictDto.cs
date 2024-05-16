using Cadastre.Common;
using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("District")]
public class ImportDistrictDto
{
    [XmlAttribute("Region")]
    [Range(TableConstraints.DistrictRegionEnumMin, TableConstraints.DistrictRegionEnumMax)]
    [Required]
    public Region Region { get; set; }

    [XmlElement("Name")]
    [Range(TableConstraints.DistrictNameMinLength, TableConstraints.DistrictNameMaxLength)]
    [Required]
    public string Name { get; set; } = null!;

    [XmlElement("PostalCode")]
    [Range(TableConstraints.DistrictPostalCodeLength, TableConstraints.DistrictPostalCodeLength)]
    [RegularExpression(TableConstraints.DistrictPostalCodeRegex)]
    [Required]
    public string PostalCode { get; set; } = null!;

    [XmlArray("Properties")]
    public ImportPropertyDto[] Properties { get; set; } = null!;
}
