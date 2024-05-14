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

    [StringLength(TableConstraints.DistrictNameMaximumLength, MinimumLength = TableConstraints.DistrictNameMinimumLength)]
    public string Name { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public Region Region { get; set; }

    public virtual ICollection<Property> Properties { get; set; } = null!;

}
