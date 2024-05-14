using Cadastre.Data.Enumerations;

namespace Cadastre.Data.Models;
public class Citizen
{
    public Citizen()
    {
        PropertiesCitizens = new HashSet<PropertyCitizen>();
    }
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public MaritalStatus MaritalStatus { get; set; }

    public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = null!;
}
