using Medicines.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos;

[XmlType("Pharmacy")]
public class ImportPharmacyDto
{
    [XmlAttribute("non-stop")]
    [Required]
    public string IsNonStop { get; set; } = null!;

    [XmlElement("Name")]
    [StringLength(TableConstraints.PharmacyNameMaxLength, MinimumLength = TableConstraints.PharmacyNameMinLength)]
    [Required]
    public string Name { get; set; } = null!;

    [XmlElement("PhoneNumber")]
    [StringLength(TableConstraints.PharmacyPhoneNumberLength, MinimumLength = TableConstraints.PharmacyPhoneNumberLength)]
    [RegularExpression(TableConstraints.PharmacyPhoneNumberRegex)]
    [Required]
    public string PhoneNumber { get; set; } = null!;

    [XmlArray("Medicines")]
    public ImportMedicineDto[] Medicines { get; set; } = null!;
}
