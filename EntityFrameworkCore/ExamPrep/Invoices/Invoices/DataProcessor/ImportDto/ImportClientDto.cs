using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto;

[XmlType("Client")]
public class ImportClientDto
{
    [XmlAttribute("Name")]
    [Required]
    [StringLength(TableConstraints.ClientNameMaxLength, MinimumLength = TableConstraints.ClientNameMinLength)]
    public string Name { get; set; }

    [XmlAttribute("NumberVat")]
    [Required]
    [StringLength(TableConstraints.ClientVatMaxLength, MinimumLength = TableConstraints.ClientVatMinLength)]
    public string NumberVat { get; set; }


}
