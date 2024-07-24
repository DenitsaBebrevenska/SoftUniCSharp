using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto;

[XmlType("Invoice")]
public class ExportInvoiceDto
{
    [XmlElement("InvoiceNumber")]
    public int Number { get; set; }

    [XmlElement("InvoiceAmount")]
    public double Amount { get; set; }

    [XmlElement("DueDate")]
    public string DueDate { get; set; } = null!;

    [XmlElement("Currency")]
    public string CurrencyType { get; set; } = null!;

}
