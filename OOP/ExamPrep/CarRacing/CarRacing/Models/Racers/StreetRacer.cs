using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    internal class StreetRacer : Racer
    {
        private const int StreetRacerExperience = 10;
        private const string StreetRacerBehavior = "aggressive";
        private const int StreetRacerExperienceGain = 5;

        public StreetRacer(string username, ICar car)
            : base(username, StreetRacerBehavior, StreetRacerExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += StreetRacerExperienceGain;
        }
    }
}
