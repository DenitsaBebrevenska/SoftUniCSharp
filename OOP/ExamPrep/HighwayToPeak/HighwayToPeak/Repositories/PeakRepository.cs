using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories;
public class PeakRepository : IRepository<IPeak>
{
    private List<IPeak> _peaks;

    public PeakRepository()
    {
        _peaks = new List<IPeak>();
    }
    public IReadOnlyCollection<IPeak> All => _peaks.AsReadOnly();
    public void Add(IPeak model)
      => _peaks.Add(model);


    public IPeak Get(string name)
        => _peaks.FirstOrDefault(p => p.Name == name);
}
