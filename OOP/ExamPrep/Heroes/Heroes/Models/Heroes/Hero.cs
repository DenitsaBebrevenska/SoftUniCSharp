using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armor;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }
                name = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroHealthBelowZero);
                }
                health = value;
            }
        }

        public int Armour
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroArmourBelowZero);
                }
                armor = value;
            }
        }

        public IWeapon Weapon
        {
            get => weapon;
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNull);
                }
            }
        }
        public bool IsAlive => Health > 0;
        public void TakeDamage(int points)
        {
            if (Armour > points)
            {
                Armour -= points;
            }
            else
            {
                int transferPoints = points - Armour;
                Armour = 0;

                if (transferPoints < Health)
                {
                    Health -= transferPoints;
                }
                else
                {
                    Health = 0;
                }
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }
    }
}
