namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.increasedConsumption = increasedConsumption;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        public string Drive(double kilometers)
        {
            double neededFuel = (FuelConsumption + increasedConsumption) * kilometers;

            if (FuelQuantity < neededFuel)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= neededFuel;

            return ($"{GetType().Name} travelled {kilometers} km");
        }

        public virtual void Refuel(double fuel) => FuelQuantity += fuel;

        public override string ToString() => $"{GetType().Name}: {FuelQuantity:F2}";
    }
}
