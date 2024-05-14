namespace Cadastre.Data.Models;
public class PropertyCitizen
{
    public int PropertyId { get; set; }

    public virtual Property Property { get; set; } = null!;

    public int CitizenId { get; set; }

    public virtual Citizen Citizen { get; set; } = null!;
}
