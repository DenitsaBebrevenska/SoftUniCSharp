using Cadastre.Common;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.Data.Models;
public class Property
{
    public Property()
    {
        PropertiesCitizens = new HashSet<PropertyCitizen>();
    }

    public int Id { get; set; }

    [MaxLength(TableConstraints.PropertyIdentifierMaxLength)]
    public string PropertyIdentifier { get; set; } = null!;

    public int Area { get; set; }

    [MaxLength(TableConstraints.PropertyDetailsMaxLength)]
    public string? Details { get; set; }

    [MaxLength(TableConstraints.PropertyAddressMaxLength)]
    public string Address { get; set; } = null!;

    public DateTime DateOfAcquisition { get; set; }

    public int DistrictId { get; set; }

    public virtual District District { get; set; } = null!;

    public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = null!;
}
