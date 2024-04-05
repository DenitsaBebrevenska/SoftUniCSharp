using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double SuperCarFuelAvailable = 65;
        private const double SuperCarFuelConsumption = 7.5;
        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, SuperCarFuelAvailable, SuperCarFuelConsumption)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower = (int)Math.Round(HorsePower * 0.97);
        }
    }
}
