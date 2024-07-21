using Invoices.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models;
public class Client
{
    public Client()
    {
        Invoices = new HashSet<Invoice>();
        Addresses = new HashSet<Address>();
        ProductsClients = new HashSet<ProductClient>();
    }
    public int Id { get; set; }

    [MaxLength(TableConstraints.ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(TableConstraints.ClientVatMaxLength)]
    public string NumberVat { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = null!;

    public virtual ICollection<ProductClient> ProductsClients { get; set; } = null!;
}
