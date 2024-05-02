using P03_SalesDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Models;
public class Product
{
    public Product()
    {
        Sales = new HashSet<Sale>();
    }
    public int ProductId { get; set; }

    [MaxLength(ValidationConstraints.ProductNameLength)]
    public string Name { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Sale> Sales { get; set; }
}
