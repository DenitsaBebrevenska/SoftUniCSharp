using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Models;
public class Customer
{
    public Customer()
    {
        Sales = new HashSet<Sale>();
    }
    public int CustomerId { get; set; }

    [MaxLength(ValidationConstraints.CustomerNameLength)]
    public string Name { get; set; }

    [Unicode(false)]
    [MaxLength(ValidationConstraints.CustomerEmailLength)]
    public string Email { get; set; }

    [MaxLength(ValidationConstraints.CustomerCreditCardLength)]
    public string CreditCardNumber { get; set; }

    public virtual ICollection<Sale> Sales { get; set; }
}
