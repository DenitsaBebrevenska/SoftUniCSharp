using Invoices.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models;
public class Address
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.AddressStreetNameMaxLength)]
    public string StreetName { get; set; } = null!;

    public int StreetNumber { get; set; }

    public string PostCode { get; set; } = null!;

    [MaxLength(TableConstraints.AddressCityMaxLength)]
    public string City { get; set; } = null!;

    [MaxLength(TableConstraints.AddressCountryMaxLength)]
    public string Country { get; set; } = null!;

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
