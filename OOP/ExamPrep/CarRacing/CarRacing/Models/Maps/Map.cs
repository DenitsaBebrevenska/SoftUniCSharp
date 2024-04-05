using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        private const double StrictBehaviorMultiplier = 1.2;
        private const double AggressiveBehaviorMultiplier = 1.1;
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable() || !racerTwo.IsAvailable())
            {
                string winnerName = racerOne.IsAvailable() ? racerOne.Username : racerTwo.Username;
                string loserName = !racerOne.IsAvailable() ? racerOne.Username : racerTwo.Username;

                return string.Format(OutputMessages.OneRacerIsNotAvailable, winnerName, loserName);
            }

            racerOne.Race();
            racerTwo.Race();

            string raceWinner = CalculateWinningChance(racerOne) > CalculateWinningChance(racerTwo)
                ? racerOne.Username
                : racerTwo.Username;
            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, raceWinner);
        }

        private double CalculateWinningChance(IRacer racer)
        {
            if (racer.RacingBehavior == "aggressive")
            {
                return racer.Car.HorsePower * racer.DrivingExperience * AggressiveBehaviorMultiplier;
            }

            return racer.Car.HorsePower * racer.DrivingExperience * StrictBehaviorMultiplier;
        }
    }
}
