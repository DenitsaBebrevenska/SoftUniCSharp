namespace EDriveRent.Models.Vehicles
{
    public class CargoVan : Vehicle
    {
        private const double MaxMileageCargoVan = 180;
        public CargoVan(string brand, string model, string licensePlateNumber)
            : base(brand, model, MaxMileageCargoVan, licensePlateNumber)
        {
        }
    }
}
