using System;

namespace EDriveRent.Models.Vehicles
{
    public class CargoVan : Vehicle
    {
        private const double MaxMileageCargoVan = 180;
        public CargoVan(string brand, string model, string licensePlateNumber)
            : base(brand, model, MaxMileageCargoVan, licensePlateNumber)
        {
        }

        public override void Drive(double mileage)
        {
            double percentage = mileage / MaxMileage * 100 + 5;
            BatteryLevel -= (int)Math.Round(percentage);
        }
    }
}
