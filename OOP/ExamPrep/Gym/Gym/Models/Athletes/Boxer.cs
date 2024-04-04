using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int BoxerInitialStamina = 60;

        private const int BoxerExerciseStaminaIncrease = 15;
        //Can train only in a BoxingGym.
        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, BoxerInitialStamina)
        {
        }

        public override void Exercise()
        {
            if (Stamina + BoxerExerciseStaminaIncrease > 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }

            Stamina += BoxerExerciseStaminaIncrease;
        }
    }
}
