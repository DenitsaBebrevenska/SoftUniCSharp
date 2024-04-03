using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;

        public Pilot(string fullName)
        {
            FullName = fullName;
            CanRace = false;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
            }
        }
        public IFormulaOneCar Car { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanRace { get; private set; }
        public void AddCar(IFormulaOneCar car)
        {
            if (car is null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
            }

            Car = car;
            CanRace = true;
        }

        public void WinRace()
            => NumberOfWins++;

        public override string ToString()
            => $"Pilot {FullName} has {NumberOfWins} wins.";
    }
}
