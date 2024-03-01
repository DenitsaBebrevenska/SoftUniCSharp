using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models.Divers;
public abstract class Diver : IDiver
{
    private string _name;
    private int _oxygenLevel;
    private List<string> _catch;
    private double _competitionPoints;
    private bool _hasHealthIssues;
    protected Diver(string name, int oxygenLevel)
    {
        Name = name;
        OxygenLevel = oxygenLevel;
        _catch = new List<string>();
        CompetitionPoints = 0;
        HasHealthIssues = false;
    }

    public string Name
    {
        get => _name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.DiversNameNull);
            }
            _name = value;
        }
    }

    public int OxygenLevel
    {
        get => _oxygenLevel;
        protected set
        {
            if (value < 0)
            {
                _oxygenLevel = 0;
            }
            else
            {
                _oxygenLevel = value;
            }
        }
    }
    public IReadOnlyCollection<string> Catch => _catch.AsReadOnly();

    public double CompetitionPoints
    {
        get => Math.Round(_competitionPoints, 1);
        private set => _competitionPoints = value;
    }
    public bool HasHealthIssues { get; private set; }
    public void Hit(IFish fish)
    {
        OxygenLevel -= fish.TimeToCatch;
        _catch.Add(fish.Name);
        CompetitionPoints += fish.Points;
    }

    public abstract void Miss(int timeToCatch);

    public void UpdateHealthStatus()
    {
        HasHealthIssues = !HasHealthIssues;
    }

    public abstract void RenewOxy();

    public override string ToString() =>
            $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
}
