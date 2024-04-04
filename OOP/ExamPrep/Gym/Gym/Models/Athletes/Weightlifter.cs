using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int WeightlifterInitialStamina = 50;
        //Can train only in a WeightliftingGym.
        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, WeightlifterInitialStamina)
        {
        }

        public override void Exercise()
        {
            if (Stamina + WeightlifterInitialStamina > 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }

            Stamina += WeightlifterInitialStamina;
        }
    }
}
