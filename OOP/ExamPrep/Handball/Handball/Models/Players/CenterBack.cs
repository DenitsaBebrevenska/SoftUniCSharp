namespace Handball.Models.Players
{
    public class CenterBack : Player
    {
        private const double CenterBackInitialRating = 4;
        private const double CenterBackRateIncrease = 1;
        private const double CenterBackRateDecrease = 1;
        public CenterBack(string name)
            : base(name, CenterBackInitialRating)
        {

        }

        public override void IncreaseRating()
            => Rating += CenterBackRateIncrease;

        public override void DecreaseRating()
         => Rating -= CenterBackRateDecrease;
    }
}
