using Cadastre.Data.Enumerations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("District")]
public class ImportDistrictDto
{
    [XmlAttribute("Region")]
    public Region Region { get; set; }

    [XmlElement("Name")]
    public string Name { get; set; } = null!;

    [XmlElement("PostalCode")]
    public string PostalCode { get; set; } = null!;

    [XmlArray("Properties")]
    public ImportPropertyDto[] Properties { get; set; } = null!;
}
