namespace Handball.Models.Players
{
    public class ForwardWing : Player
    {
        private const double ForwardWingInitialRating = 5.5;
        private const double ForwardWingRateIncrease = 1.25;
        private const double ForwardWingRateDecrease = 0.75;

        public ForwardWing(string name)
            : base(name, ForwardWingInitialRating)
        {
        }

        public override void IncreaseRating()
            => Rating += ForwardWingRateIncrease;

        public override void DecreaseRating()
         => Rating -= ForwardWingRateDecrease;
    }
}
