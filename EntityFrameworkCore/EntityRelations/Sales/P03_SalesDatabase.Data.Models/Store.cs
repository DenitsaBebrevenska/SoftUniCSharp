using P03_SalesDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models;
public class Store
{
    public Store()
    {
        Sales = new HashSet<Sale>();
    }
    public int StoreId { get; set; }

    [MaxLength(ValidationConstraints.StoreNameLength)]
    public string Name { get; set; }

    public virtual ICollection<Sale> Sales { get; set; }
}
