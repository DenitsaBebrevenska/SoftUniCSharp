using Footballers.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto;

[XmlType("Coach")]
public class ImportCoachDto
{
    [Required]
    [XmlElement("Name")]
    [StringLength(TableConstraints.CoachNameMaxLength, MinimumLength = TableConstraints.CoachNameMinLength)]
    public string Name { get; set; } = null!;


    [Required]
    [XmlElement("Nationality")]
    public string Nationality { get; set; } = null!;

    [XmlArray("Footballers")]
    public ImportFootballerDto[] Footballers { get; set; }
}
