using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

public class ExportProductsWrapper
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")]
    public ExportSoldProductDto[] Products { get; set; }
}
