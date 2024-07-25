
using Boardgames.Common;
using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Boardgame")]
public class ImportBoardgameDto
{
    [XmlElement("Name")]
    [Required]
    [StringLength(TableConstraints.BoardgameNameMaxLength, MinimumLength = TableConstraints.BoardgameNameMinLength)]
    public string Name { get; set; } = null!;

    [XmlElement("Rating")]
    [Required]
    [Range(TableConstraints.BoardgameMinRating, TableConstraints.BoardgameMaxRating)]
    public double Rating { get; set; }

    [XmlElement("YearPublished")]
    [Required]
    [Range(TableConstraints.BoardgameMinYearPublished, TableConstraints.BoardgameMaxYearPublished)]
    public int YearPublished { get; set; }

    [XmlElement("CategoryType")]
    [Required]
    public CategoryType CategoryType { get; set; }

    [XmlElement("Mechanics")]
    [Required]
    public string Mechanics { get; set; } = null!;

}
