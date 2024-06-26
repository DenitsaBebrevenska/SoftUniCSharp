﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;
        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower => Math.Round(CalculateMilitaryPower(), 3);
        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
            => units.AddItem(unit);

        public void AddWeapon(IWeapon weapon)
            => weapons.AddItem(weapon);

        public void TrainArmy()
        {
            foreach (var militaryUnit in units.Models)
            {
                militaryUnit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void Profit(double amount)
            => Budget += amount;

        public string PlanetInfo()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine($"Planet: {Name}");
            info.AppendLine($"--Budget: {Budget} billion QUID");
            List<string> militaryUnitNames = new List<string>();

            foreach (var militaryUnit in units.Models)
            {
                militaryUnitNames.Add(militaryUnit.GetType().Name);
            }

            info.AppendLine(militaryUnitNames.Count == 0 ? "--Forces: No units" : $"--Forces: {string.Join(", ", militaryUnitNames)}");
            List<string> weaponNames = new List<string>();

            foreach (var weapon in weapons.Models)
            {
                weaponNames.Add(weapon.GetType().Name);
            }

            info.AppendLine(weaponNames.Count == 0
                ? "--Combat equipment: No weapons"
                : $"--Combat equipment: {string.Join(", ", weaponNames)}");
            info.AppendLine($"--Military Power: {MilitaryPower}");

            return info.ToString().TrimEnd();
        }

        private double CalculateMilitaryPower()
        {
            double amount = units.Models.Sum(u => u.EnduranceLevel) + weapons.Models.Sum(w => w.DestructionLevel);

            if (units.Models.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                amount *= 1.3;
            }

            if (weapons.Models.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                amount *= 1.45;
            }

            return amount;
        }
    }
}
