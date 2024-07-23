using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto;

[XmlType("Address")]
public class ImportAddressDto
{
    [XmlAttribute("StreetName")]
    [Required]
    [StringLength(TableConstraints.AddressStreetNameMaxLength, MinimumLength = TableConstraints.AddressStreetNameMinLength)]
    public string StreetName { get; set; }

    [XmlAttribute("StreetNumber")]
    [Required]
    public int StreetNumber { get; set; }

    [XmlAttribute("PostCode")]
    [Required]
    public string PostCode { get; set; }

    [XmlAttribute("City")]
    [Required]
    [StringLength(TableConstraints.AddressCityMaxLength, MinimumLength = TableConstraints.AddressCityMinLength)]
    public string City { get; set; }

    [XmlAttribute("Country")]
    [Required]
    [StringLength(TableConstraints.AddressCountryMaxLength, MinimumLength = TableConstraints.AddressCountryMinLength)]
    public string Country { get; set; }

}
