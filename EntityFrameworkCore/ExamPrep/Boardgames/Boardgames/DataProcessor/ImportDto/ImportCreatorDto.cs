using Boardgames.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Creator")]
public class ImportCreatorDto
{
    [XmlElement("FirstName")]
    [Required]
    [StringLength(TableConstraints.CreatorFirstNameMaxLength, MinimumLength = TableConstraints.CreatorFirstNameMinLength)]
    public string FirstName { get; set; } = null!;

    [XmlElement("LastName")]
    [Required]
    [StringLength(TableConstraints.CreatorLastNameMaxLength, MinimumLength = TableConstraints.CreatorLastNameMinLength)]
    public string LastName { get; set; } = null!;

    [XmlArray("Boardgames")]
    public ImportBoardgameDto[] Boardgames { get; set; }
}
