using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models;
public class Peak : IPeak
{
    private string _name;
    private int _elevation;
    private string _difficultyLevel;
    public Peak(string name, int elevation, string difficultyLevel)
    {
        Name = name;
        Elevation = elevation;
        DifficultyLevel = difficultyLevel;
    }

    public string Name
    {
        get => _name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
            }

            _name = value;
        }
    }

    public int Elevation
    {
        get => _elevation;
        private set
        {
            if (value < 0) //is zero considered positive here?
            {
                throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
            }
            _elevation = value;
        }
    }

    public string DifficultyLevel // todo I would rather use enums but...
    {
        get => _difficultyLevel;
        private set
        {
            if (value.ToLower() == "moderate")
            {
                _difficultyLevel = "Moderate";
            }
            else if (value.ToLower() == "hard")
            {
                _difficultyLevel = "Hard";
            }
            else if (value.ToLower() == "extreme")
            {
                _difficultyLevel = "Extreme";
            }
        }
    }

    public override string ToString()
        => $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
}
