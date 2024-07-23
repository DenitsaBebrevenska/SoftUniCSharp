using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto;

[XmlType("Address")]
public class ImportAddressDto
{
    [XmlElement("StreetName")]
    [Required]
    [StringLength(TableConstraints.AddressStreetNameMaxLength, MinimumLength = TableConstraints.AddressStreetNameMinLength)]
    public string StreetName { get; set; } = null!;

    [XmlElement("StreetNumber")]
    [Required]
    public int StreetNumber { get; set; }

    [XmlElement("PostCode")]
    [Required]
    public string PostCode { get; set; } = null!;

    [XmlElement("City")]
    [Required]
    [StringLength(TableConstraints.AddressCityMaxLength, MinimumLength = TableConstraints.AddressCityMinLength)]
    public string City { get; set; } = null!;

    [XmlElement("Country")]
    [Required]
    [StringLength(TableConstraints.AddressCountryMaxLength, MinimumLength = TableConstraints.AddressCountryMinLength)]
    public string Country { get; set; } = null!;

}
