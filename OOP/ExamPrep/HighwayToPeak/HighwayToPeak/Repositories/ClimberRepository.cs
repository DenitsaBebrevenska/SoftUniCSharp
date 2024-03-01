using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories;
public class ClimberRepository : IRepository<IClimber>
{
    private List<IClimber> _climbers;

    public ClimberRepository()
    {
        _climbers = new List<IClimber>();
    }
    public IReadOnlyCollection<IClimber> All => _climbers.AsReadOnly();
    public void Add(IClimber model)
      => _climbers.Add(model);

    public IClimber Get(string name)
        => _climbers.FirstOrDefault(c => c.Name == name);
}
