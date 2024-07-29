using Newtonsoft.Json;

namespace Trucks.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {

        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clientsAndTrucks = context.Clients
                .Where(c => c.ClientsTrucks
                    .Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new
                {
                    c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .Select(ct => new
                        {
                            TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                            ct.Truck.VinNumber,
                            ct.Truck.TankCapacity,
                            ct.Truck.CargoCapacity,
                            ct.Truck.CategoryType,
                            ct.Truck.MakeType
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CategoryType)
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clientsAndTrucks, Formatting.Indented);
        }
    }
}
