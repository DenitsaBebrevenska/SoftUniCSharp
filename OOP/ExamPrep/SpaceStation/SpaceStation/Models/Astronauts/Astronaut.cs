using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private const double OxygenDecrease = 10;
        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
            }
        }

        public bool CanBreath => Oxygen > 0;
        public IBag Bag { get; private set; }
        public virtual void Breath()
        {
            if (Oxygen - OxygenDecrease < 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= OxygenDecrease;
            }
        }
    }
}
