namespace Handball.Models.Players
{
    public class Goalkeeper : Player
    {
        private const double GoalkeeperInitialRating = 2.5;
        private const double GoalkeeperRateIncrease = 0.75;
        private const double GoalkeeperRateDecrease = 1.25;
        public Goalkeeper(string name)
            : base(name, GoalkeeperInitialRating)
        {
        }

        public override void IncreaseRating()
            => Rating += GoalkeeperRateIncrease;

        public override void DecreaseRating()
         => Rating -= GoalkeeperRateDecrease;
    }
}
