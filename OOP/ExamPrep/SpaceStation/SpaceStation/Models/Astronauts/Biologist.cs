namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double BiologistOxygen = 70;

        protected override double OxygenDecrease => 5;

        public Biologist(string name)
            : base(name, BiologistOxygen)
        {
        }
    }
}
