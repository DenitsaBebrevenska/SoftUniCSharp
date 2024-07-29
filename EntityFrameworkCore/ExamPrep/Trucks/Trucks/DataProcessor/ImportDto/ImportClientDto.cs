using System.ComponentModel.DataAnnotations;
using Trucks.Common;

namespace Trucks.DataProcessor.ImportDto;
public class ImportClientDto
{
    [Required]
    [StringLength(TableConstraints.ClientNameMaxLength, MinimumLength = TableConstraints.ClientNameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(TableConstraints.ClientNationalityMaxLength, MinimumLength = TableConstraints.ClientNationalityMinLength)]
    public string Nationality { get; set; } = null!;

    [Required]
    public string Type { get; set; } = null!;

    public int[] Trucks { get; set; }
}
