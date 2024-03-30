using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private const double ArmyTrainingPrice = 1.25;
        private IRepository<IPlanet> planetRepository;

        public Controller()
        {
            planetRepository = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            if (planetRepository.Models.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planetRepository.AddItem(new Planet(name, budget));
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (planetRepository.Models.All(p => p.Name != planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planetRepository.FindByName(planetName);

            if (planet.Army.Any(mu => mu.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unit;

            switch (unitTypeName)
            {
                case "AnonymousImpactUnit":
                    unit = new AnonymousImpactUnit();
                    break;
                case "SpaceForces":
                    unit = new SpaceForces();
                    break;
                case "StormTroopers":
                    unit = new StormTroopers();
                    break;
                default:
                    unit = null;
                    break;
            }

            if (unit is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (planetRepository.Models.All(w => w.Name != planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planetRepository.FindByName(planetName);

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon weapon;

            switch (weaponTypeName)
            {
                case "BioChemicalWeapon":
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;
                case "NuclearWeapon":
                    weapon = new NuclearWeapon(destructionLevel);
                    break;
                case "SpaceMissiles":
                    weapon = new SpaceMissiles(destructionLevel);
                    break;
                default:
                    weapon = null;
                    break;
            }

            if (weapon is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            if (planetRepository.Models.All(p => p.Name != planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planetRepository.FindByName(planetName);

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.TrainArmy();
            planet.Spend(ArmyTrainingPrice);

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planetRepository.FindByName(planetOne);
            IPlanet secondPlanet = planetRepository.FindByName(planetTwo);
            IPlanet winner;
            IPlanet loser;

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if (firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")
                    && secondPlanet.Weapons.All(w => w.GetType().Name != "NuclearWeapon"))
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else if (firstPlanet.Weapons.All(w => w.GetType().Name != "NuclearWeapon")
                         && secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }
                else
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return string.Format(OutputMessages.NoWinner);
                }
            }
            else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                winner = firstPlanet;
                loser = secondPlanet;
            }
            else
            {
                winner = secondPlanet;
                loser = firstPlanet;
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            winner.Profit(loser.Army.Sum(mu => mu.Cost) + loser.Weapons.Sum(w => w.Price));
            planetRepository.RemoveItem(loser.Name);
            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        public string ForcesReport()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planetRepository.Models
                         .OrderByDescending(p => p.MilitaryPower)
                         .ThenBy(p => p.Name))
            {
                report.AppendLine(planet.PlanetInfo());
            }

            return report.ToString().TrimEnd();
        }
    }
}
