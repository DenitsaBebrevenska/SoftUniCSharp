using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double increasedConsumption;

        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double increasedConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.increasedConsumption = increasedConsumption;
        }

        public string Drive(double distance, bool isIncreasedConsumption = true)
        {
            double neededFuel = isIncreasedConsumption ? FuelConsumption + increasedConsumption : FuelConsumption;

            if (FuelQuantity < distance * neededFuel)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= neededFuel * distance;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (amount + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            FuelQuantity += amount;
        }

        public override string ToString() => $"{GetType().Name}: {FuelQuantity:F2}";
    }
}
