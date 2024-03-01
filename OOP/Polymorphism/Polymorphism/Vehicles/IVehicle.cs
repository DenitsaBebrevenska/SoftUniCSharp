namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        public string Drive(double kilometers);
        public void Refuel(double fuel);
    }
}
