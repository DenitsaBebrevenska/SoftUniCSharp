using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto;

[XmlType("Client")]
public class ImportClientDto
{
    [XmlElement("Name")]
    [Required]
    [StringLength(TableConstraints.ClientNameMaxLength, MinimumLength = TableConstraints.ClientNameMinLength)]
    public string Name { get; set; } = null!;

    [XmlElement("NumberVat")]
    [Required]
    [StringLength(TableConstraints.ClientVatMaxLength, MinimumLength = TableConstraints.ClientVatMinLength)]
    public string NumberVat { get; set; } = null!;

    [XmlArray("Addresses")]
    public ImportAddressDto[] Addresses { get; set; } = null!;
}
