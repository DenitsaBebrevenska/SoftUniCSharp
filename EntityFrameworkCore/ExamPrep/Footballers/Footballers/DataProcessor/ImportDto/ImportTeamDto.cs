using Footballers.Common;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto;
public class ImportTeamDto
{
    [Required]
    [StringLength(TableConstraints.TeamNameMaxLength, MinimumLength = TableConstraints.TeamNameMinLength)]
    [RegularExpression(TableConstraints.TeamNamePattern)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(TableConstraints.TeamNationalityMaxLength, MinimumLength = TableConstraints.TeamNationalityMinLength)]
    public string Nationality { get; set; } = null!;

    [Required]
    public string Trophies { get; set; } = null!;

    [Required]
    public int[] Footballers { get; set; } = null!;
}
