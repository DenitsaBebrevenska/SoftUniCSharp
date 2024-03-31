using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        protected Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.WeaponTypeNull);
                }
                name = value;
            }
        }

        public int Durability
        {
            get => durability;
            private set
            {
                if (durability < 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurabilityBelowZero);
                }
                durability = value;
            }
        }

        public virtual int DoDamage() //could be problematic for judge
        {
            Durability--;
            return 0;
        }
    }
}
