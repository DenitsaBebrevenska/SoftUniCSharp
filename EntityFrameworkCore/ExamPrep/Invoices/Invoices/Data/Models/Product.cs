using Invoices.Common;
using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models;
public class Product
{
    public Product()
    {
        ProductsClients = new HashSet<ProductClient>();
    }
    public int Id { get; set; }

    [MaxLength(TableConstraints.ProductNameMaxLength)]
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public CategoryType CategoryType { get; set; }

    public virtual ICollection<ProductClient> ProductsClients { get; set; } = null!;
}
