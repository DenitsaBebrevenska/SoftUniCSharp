using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int ProfessionalRacerExperience = 30;
        private const string ProfessionalRacerBehavior = "strict";
        private const int ProfessionalRacerExperienceGain = 10;

        public ProfessionalRacer(string username, ICar car)
            : base(username, ProfessionalRacerBehavior, ProfessionalRacerExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += ProfessionalRacerExperienceGain;
        }
    }
}
