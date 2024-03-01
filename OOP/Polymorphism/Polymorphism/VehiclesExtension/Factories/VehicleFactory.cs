using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.Models;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                case "Bus":
                    return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type");
                    break;
            }

        }
    }
}
