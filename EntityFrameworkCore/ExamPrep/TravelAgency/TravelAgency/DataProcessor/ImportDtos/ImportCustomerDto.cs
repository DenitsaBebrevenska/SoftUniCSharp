using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TravelAgency.Common;

namespace TravelAgency.DataProcessor.ImportDtos;

[XmlType("Customer")]
public class ImportCustomerDto
{
    [XmlAttribute("phoneNumber")]
    [Required]
    [StringLength(TableConstraints.CustomerPhoneNumberLength)]
    [RegularExpression(TableConstraints.CustomerPhoneNumberPattern)]
    public string PhoneNumber { get; set; } = null!;

    [XmlElement("FullName")]
    [Required]
    [StringLength(TableConstraints.CustomerNameMaxLength, MinimumLength = TableConstraints.CustomerNameMinLength)]
    public string FullName { get; set; } = null!;

    [XmlElement("Email")]
    [Required]
    [StringLength(TableConstraints.CustomerEmailMaxLength, MinimumLength = TableConstraints.CustomerEmailMinLength)]
    public string Email { get; set; } = null!;
}
