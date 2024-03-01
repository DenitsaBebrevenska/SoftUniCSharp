using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Core;
public class Controller : IController
{
    private IRepository<IPeak> _peaks;
    private IRepository<IClimber> _climbers;
    private IBaseCamp _baseCamp;
    private readonly string[] _validDifficultyLevels = new[] { "extreme", "hard", "moderate" };
    public Controller()
    {
        _peaks = new PeakRepository();
        _climbers = new ClimberRepository();
        _baseCamp = new BaseCamp();
    }
    public string AddPeak(string name, int elevation, string difficultyLevel)
    {
        if (_peaks.All.Any(p => p.Name == name))
        {
            return string.Format(OutputMessages.PeakAlreadyAdded, name);
        }

        if (!_validDifficultyLevels.Contains(difficultyLevel.ToLower()))
        {
            return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
        }

        _peaks.Add(new Peak(name, elevation, difficultyLevel));
        return string.Format(OutputMessages.PeakIsAllowed, name, _peaks.GetType().Name); //todo not sure about the type
    }

    public string NewClimberAtCamp(string name, bool isOxygenUsed)
    {
        if (_climbers.All.Any(c => c.Name == name))
        {
            return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, _climbers.GetType().Name); //todo not sure about the type
        }

        IClimber climber;

        if (isOxygenUsed)
        {
            climber = new OxygenClimber(name);
        }
        else
        {
            climber = new NaturalClimber(name);
        }

        _climbers.Add(climber);
        _baseCamp.ArriveAtCamp(name);

        return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
    }

    public string AttackPeak(string climberName, string peakName)
    {
        if (_climbers.All.All(c => c.Name != climberName))
        {
            return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
        }

        if (_peaks.All.All(p => p.Name != peakName))
        {
            return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
        }

        if (_baseCamp.Residents.All(r => r != climberName))
        {
            return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
        }

        IClimber currentClimber = _climbers.All.FirstOrDefault(c => c.Name == climberName);
        IPeak currentPeak = _peaks.All.FirstOrDefault(p => p.Name == peakName);

        if (currentPeak.DifficultyLevel == "Extreme" && currentClimber is NaturalClimber)
        {
            return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
        }

        currentClimber.Climb(currentPeak);
        _baseCamp.LeaveCamp(currentClimber.Name);

        if (currentClimber.Stamina == 0)
        {
            return string.Format(OutputMessages.NotSuccessfullAttack, currentClimber.Name);
        }

        _baseCamp.ArriveAtCamp(currentClimber.Name);
        return string.Format(OutputMessages.SuccessfulAttack, currentClimber.Name, currentPeak.Name);

    }

    public string CampRecovery(string climberName, int daysToRecover)
    {
        if (_baseCamp.Residents.All(r => r != climberName))
        {
            return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
        }

        IClimber climber = _climbers.All.FirstOrDefault(c => c.Name == climberName);

        if (climber.Stamina == 10)
        {
            return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
        }

        climber.Rest(daysToRecover);

        return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
    }

    public string BaseCampReport()
    {
        if (_baseCamp.Residents.Count == 0)
        {
            return "BaseCamp is currently empty.";
        }

        StringBuilder reportBuilder = new StringBuilder();
        reportBuilder.AppendLine("BaseCamp residents:");

        foreach (string resident in _baseCamp.Residents)
        {
            IClimber currentClimber = _climbers.All.FirstOrDefault(c => c.Name == resident);

            if (currentClimber != null)
            {
                reportBuilder.AppendLine($"Name: {currentClimber.Name}, Stamina: {currentClimber.Stamina}, Count of Conquered Peaks: {currentClimber.ConqueredPeaks.Count}");
            }
        }

        return reportBuilder.ToString().TrimEnd();
    }

    public string OverallStatistics()
    {
        StringBuilder statisticsBuilder = new StringBuilder();
        statisticsBuilder.AppendLine("***Highway-To-Peak***");

        foreach (var climber in _climbers.All.OrderByDescending(c => c.ConqueredPeaks.Count)
                     .ThenBy(c => c.Name))
        {
            statisticsBuilder.AppendLine(climber.ToString());
            List<IPeak> climberPeaks = new List<IPeak>();

            foreach (var peakName in climber.ConqueredPeaks)
            {
                IPeak currentPeak = _peaks.All.First(p => p.Name == peakName);
                climberPeaks.Add(currentPeak);
            }

            foreach (var peak in climberPeaks.OrderByDescending(p => p.Elevation))
            {
                statisticsBuilder.AppendLine(peak.ToString());
            }
        }
        return statisticsBuilder.ToString().TrimEnd();
    }
}
