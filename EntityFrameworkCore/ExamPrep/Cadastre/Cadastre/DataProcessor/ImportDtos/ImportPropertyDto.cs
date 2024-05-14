using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("Property")]
public class ImportPropertyDto
{
    [XmlElement("PropertyIdentifier")]
    public string PropertyIdentifier { get; set; } = null!;

    [XmlElement("Area")]
    public int Area { get; set; }

    [XmlElement("Details")]
    public string? Details { get; set; }

    [XmlElement("Address")]
    public string Address { get; set; } = null!;

    [XmlElement("DateOfAcquisition")]
    public string DateOfAcquisition { get; set; } = null!;
}
