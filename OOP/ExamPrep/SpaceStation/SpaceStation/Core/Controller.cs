using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private IMission mission;
        private const int MinimumOxygenLevelForExpedition = 60;
        private int exploredPlanets = 0;
        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            mission = new Mission();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;
                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;
                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (string item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            var missionExplorers = astronauts.Models
                .Where(a => a.Oxygen > MinimumOxygenLevelForExpedition)
                .ToList();

            if (missionExplorers.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = planets.FindByName(planetName);

            mission.Explore(planet, missionExplorers);
            exploredPlanets++;

            return string.Format(OutputMessages.PlanetExplored, planetName,
                missionExplorers.Count(me => !me.CanBreath));
        }

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"{exploredPlanets} planets were explored!");
            reportBuilder.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                reportBuilder.AppendLine($"Name: {astronaut.Name}");
                reportBuilder.AppendLine($"Oxygen: {astronaut.Oxygen}");
                string astronautItems = astronaut.Bag.Items.Count == 0 ? "none" : $"{string.Join(", ", astronaut.Bag.Items)}";
                reportBuilder.AppendLine($"Bag items: {astronautItems}");
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
