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

    [StringLength(TableConstraints.PropertyIdentifierMaxLength, MinimumLength = TableConstraints.PropertyIdentifierMinLength)]
    public string PropertyIdentifier { get; set; } = null!;

    [Range(TableConstraints.PropertyAreaMinValue, TableConstraints.PropertyAreaMaxValue)]
    public uint Area { get; set; }

    [StringLength(TableConstraints.PropertyDetailsMaxLength, MinimumLength = TableConstraints.PropertyDetailsMinLength)]
    public string? Details { get; set; }

    [StringLength(TableConstraints.PropertyAddressMaxLength, MinimumLength = TableConstraints.PropertyAddressMinLength)]
    public string? Address { get; set; }

    public DateTime DateOfAcquisition { get; set; }

    public int DistrictId { get; set; }

    public virtual District District { get; set; } = null!;

    public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = null!;
}
