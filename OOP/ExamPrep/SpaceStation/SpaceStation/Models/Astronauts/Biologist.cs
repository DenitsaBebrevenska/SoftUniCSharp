namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double BiologistOxygen = 70;
        private const double BiologistOxygenDecrease = 5;

        public Biologist(string name)
            : base(name, BiologistOxygen)
        {
        }

        public override void Breath()
        {
            if (Oxygen - BiologistOxygenDecrease < 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= BiologistOxygenDecrease;
            }
        }
    }
}
