using Cadastre.Common;
using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.Data.Models;
public class Citizen
{
    public Citizen()
    {
        PropertiesCitizens = new HashSet<PropertyCitizen>();
    }
    public int Id { get; set; }

    [StringLength(TableConstraints.CitizenFirstNameMaxLength, MinimumLength = TableConstraints.CitizenFirstNameMinLength)]
    public string FirstName { get; set; } = null!;

    [StringLength(TableConstraints.CitizenLastNameMaxLength, MinimumLength = TableConstraints.CitizenLastNameMinLength)]
    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public MaritalStatus MaritalStatus { get; set; }

    public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = null!;
}
