using Medicines.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos;

[XmlType("Medicine")]
public class ImportMedicineDto
{
    [XmlAttribute("category")]
    [Required]
    [Range((int)Data.Models.Enums.Category.Analgesic, (int)Data.Models.Enums.Category.Vaccine)]
    public int Category { get; set; }

    [XmlElement("Name")]
    [StringLength(TableConstraints.MedicineNameMaxLength, MinimumLength = TableConstraints.MedicineNameMinLength)]
    [Required]
    public string Name { get; set; } = null!;

    [XmlElement("Price")]
    [Range(TableConstraints.MedicinePriceMinValue, TableConstraints.MedicinePriceMaxValue)]
    [Required]
    public double Price { get; set; }

    [XmlElement("ProductionDate")]
    [Required]
    public string ProductionDate { get; set; } = null!;

    [XmlElement("ExpiryDate")]
    [Required]
    public string ExpiryDate { get; set; } = null!;

    [XmlElement("Producer")]
    [StringLength(TableConstraints.MedicineProducerMaxLength, MinimumLength = TableConstraints.MedicineProducerMinLength)]
    [Required]
    public string Producer { get; set; } = null!;
}
