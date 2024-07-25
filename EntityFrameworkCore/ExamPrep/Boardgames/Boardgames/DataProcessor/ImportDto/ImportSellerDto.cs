using Boardgames.Common;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto;
public class ImportSellerDto
{
    [Required]
    [StringLength(TableConstraints.SellerNameMaxLength, MinimumLength = TableConstraints.SellerNameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(TableConstraints.SellerAddressMaxLength, MinimumLength = TableConstraints.SellerAddressMinLength)]
    public string Address { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

    [Required]
    [RegularExpression(TableConstraints.SellerWebsitePattern)]
    public string Website { get; set; } = null!;

    public int[] Boardgames { get; set; }
}
