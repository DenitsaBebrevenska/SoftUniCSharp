using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;
        private IMap map;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
            map = new Map();
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponAlreadyExists, name));
            }

            IWeapon weapon;

            switch (type)
            {
                case "Mace":
                    weapon = new Mace(name, durability);
                    break;
                case "Claymore":
                    weapon = new Claymore(name, durability);
                    break;
                default:
                    throw new InvalidOperationException(string.Format(OutputMessages.WeaponTypeIsInvalid));
            }

            weapons.Add(weapon);
            return string.Format(OutputMessages.WeaponAddedSuccessfully, weapon.GetType().Name.ToLower(), weapon.Name);
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyExist, name));
            }

            IHero hero;

            switch (type)
            {
                case "Barbarian":
                    hero = new Barbarian(name, health, armour);
                    heroes.Add(hero);
                    return string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
                case "Knight":
                    hero = new Knight(name, health, armour);
                    heroes.Add(hero);
                    return string.Format(OutputMessages.SuccessfullyAddedKnight, name);
                default:
                    throw new InvalidOperationException(string.Format(OutputMessages.HeroTypeIsInvalid));
            }
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);

            if (hero is null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroDoesNotExist, heroName));
            }

            IWeapon weapon = weapons.FindByName(weaponName);

            if (weapon is null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponDoesNotExist, weaponName));
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName));
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return string.Format(OutputMessages.WeaponAddedToHero, heroName, weapon.GetType().Name.ToLower());
        }

        public string StartBattle()
         => map.Fight(heroes.Models.Where(h => h.Weapon != null && h.IsAlive).ToList());

        public string HeroReport()
        {
            StringBuilder report = new StringBuilder();

            foreach (var hero in heroes.Models.OrderBy(h => h.GetType().Name)
                         .ThenByDescending(h => h.Health)
                         .ThenBy(h => h.Name))
            {
                report.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                report.AppendLine($"--Health: {hero.Health}");
                report.AppendLine($"--Armour: {hero.Armour}");
                report.AppendLine(hero.Weapon is null ? "--Weapon: Unarmed" : $"--Weapon: {hero.Weapon.Name}");
            }

            return report.ToString().TrimEnd();
        }
    }
}
