using Invoices.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto;
public class ImportProductDto
{
    [Required]
    [StringLength(TableConstraints.ProductNameMaxLength, MinimumLength = TableConstraints.ProductNameMinLength)]
    public string Name { get; set; }

    [Required]
    [Range((double)TableConstraints.ProductMinPrice, (double)TableConstraints.ProductMaxPrice)]
    public decimal Price { get; set; }

    [Required]
    public int CategoryType { get; set; }

    public ICollection<int> Clients { get; set; } = new List<int>();

}
