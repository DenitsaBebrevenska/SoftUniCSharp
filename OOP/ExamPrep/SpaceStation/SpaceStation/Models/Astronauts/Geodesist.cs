namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double GeodesistOxygen = 70;
        public Geodesist(string name)
            : base(name, GeodesistOxygen)
        {
        }
    }
}
