using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models;
public class BaseCamp : IBaseCamp
{
    private readonly List<string> _residents;

    public BaseCamp()
    {

        _residents = new List<string>();
    }

    public IReadOnlyCollection<string> Residents => _residents.OrderBy(r => r).ToList().AsReadOnly();
    public void ArriveAtCamp(string climberName)
    {
        if (_residents.All(r => r != climberName))
        {
            _residents.Add(climberName);
        }
    }

    public void LeaveCamp(string climberName)
    {
        if (_residents.Any(r => r == climberName))
        {
            _residents.Remove(climberName);
        }
    }
}
