using Cadastre.Common;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.DataProcessor.ImportDtos;
public class ImportCitizenDto
{
    [StringLength(TableConstraints.CitizenFirstNameMaxLength, MinimumLength = TableConstraints.CitizenFirstNameMinLength)]
    [Required]
    public string FirstName { get; set; } = null!;

    [StringLength(TableConstraints.CitizenLastNameMaxLength, MinimumLength = TableConstraints.CitizenLastNameMinLength)]
    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string BirthDate { get; set; } = null!;

    [Required]
    public string MaritalStatus { get; set; } = null!;

    public int[] Properties { get; set; } = null!;
}
