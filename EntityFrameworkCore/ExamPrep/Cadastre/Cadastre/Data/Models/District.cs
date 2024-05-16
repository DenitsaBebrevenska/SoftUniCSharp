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

    [MaxLength(TableConstraints.DistrictNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(TableConstraints.DistrictPostalCodeLength)]
    public string PostalCode { get; set; } = null!;

    [Required]
    public Region Region { get; set; }

    public virtual ICollection<Property> Properties { get; set; } = null!;

}
