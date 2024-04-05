using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> planetItems = planet.Items.ToList();

            for (int i = 0; i < planetItems.Count; i++)
            {
                foreach (var astronaut in astronauts.Where(a => a.CanBreath).ToList())
                {
                    if (astronaut.Oxygen > 0)
                    {
                        string item = planetItems[i];
                        astronaut.Breath();
                        astronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                        break;
                    }
                }
            }
        }
    }
}
