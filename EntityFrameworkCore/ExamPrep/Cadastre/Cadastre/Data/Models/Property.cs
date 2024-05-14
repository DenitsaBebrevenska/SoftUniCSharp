namespace Cadastre.Data.Models;
public class Property
{
    public Property()
    {
        PropertiesCitizens = new HashSet<PropertyCitizen>();
    }

    public int Id { get; set; }

    public string PropertyIdentifier { get; set; } = null!;

    public uint Area { get; set; }

    public string? Details { get; set; }

    public string? Address { get; set; }

    public DateTime DateOfAcquisition { get; set; }

    public int DistrictId { get; set; }

    public virtual District District { get; set; } = null!;

    public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = null!;
}
