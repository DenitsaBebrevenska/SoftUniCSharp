using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;

namespace PlanetWars.Models.MilitaryUnits
{
    public class MilitaryUnit : IMilitaryUnit
    {
        public MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = 1;
        }

        public double Cost { get; private set; }
        public int EnduranceLevel { get; private set; }
        public void IncreaseEndurance()
        {
            if (EnduranceLevel + 1 > 20)
            {
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
            EnduranceLevel += 1;
        }
    }
}
