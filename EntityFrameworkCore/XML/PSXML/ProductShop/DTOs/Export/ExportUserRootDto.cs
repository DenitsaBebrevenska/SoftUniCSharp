using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlRoot("Users")]
public class ExportUserRootDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    public ExportUserWithAgeDto[] Users { get; set; }
}
