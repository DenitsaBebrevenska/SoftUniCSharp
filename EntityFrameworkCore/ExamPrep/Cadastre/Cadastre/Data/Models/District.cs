using Cadastre.Common;
using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.Data.Models;
public class District
{
    public District()
    {
        Properties = new HashSet<Property>();
    }
    public int Id { get; set; }

    [StringLength(TableConstraints.DistrictNameMaxLength, MinimumLength = TableConstraints.DistrictNameMinLength)]
    public string Name { get; set; } = null!;

    [StringLength(TableConstraints.DistrictPostalCodeLength)]
    [RegularExpression(TableConstraints.DistrictPostalCodeRegex)]
    public string PostalCode { get; set; } = null!;

    public Region Region { get; set; }

    public virtual ICollection<Property> Properties { get; set; } = null!;

}
