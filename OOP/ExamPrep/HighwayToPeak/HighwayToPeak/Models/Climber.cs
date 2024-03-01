using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Models;
public abstract class Climber : IClimber
{
    private string _name;
    private int _stamina;
    private List<string> _conqueredPeaks;

    protected Climber(string name, int stamina)
    {
        Name = name;
        Stamina = stamina;
        _conqueredPeaks = new List<string>();
    }

    public string Name
    {
        get => _name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
            }
            _name = value;
        }

    }

    public int Stamina
    {
        get => _stamina;
        protected set
        {
            if (value < 0)
            {
                _stamina = 0;
            }
            else if (value > 10)
            {
                _stamina = 10;
            }
            else
            {
                _stamina = value;
            }
        }
    }

    public IReadOnlyCollection<string> ConqueredPeaks => _conqueredPeaks.AsReadOnly();
    public void Climb(IPeak peak)
    {
        string peakFound = _conqueredPeaks.FirstOrDefault(p => p == peak.Name);

        if (peakFound == null)
        {
            _conqueredPeaks.Add(peak.Name);
        }

        ReduceStamina(peak.DifficultyLevel);
    }

    public abstract void Rest(int daysCount);

    private int CalculateStaminaReduction(string difficulty)
    {
        switch (difficulty)
        {
            case "Extreme":
                return 6;
            case "Hard":
                return 4;
            case "Moderate":
                return 2;
        }

        return default;
    }

    private void ReduceStamina(string difficulty) //todo will that set correctly stamina?
    {
        int reduction = CalculateStaminaReduction(difficulty);

        Stamina -= reduction;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{GetType().Name} - Name: {Name}, Stamina: {Stamina}");
        string peaksConquered = _conqueredPeaks.Count == 0 ? "no peaks conquered" : $"{_conqueredPeaks.Count}";
        sb.AppendLine($"Peaks conquered: {peaksConquered}");

        return sb.ToString().TrimEnd();
    }
}
