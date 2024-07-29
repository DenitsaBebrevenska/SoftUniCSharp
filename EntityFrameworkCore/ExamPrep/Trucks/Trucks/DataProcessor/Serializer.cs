using Newtonsoft.Json;
using Trucks.Common;
using Trucks.DataProcessor.ExportDto;

namespace Trucks.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchersAndTrucks = context.Despatchers
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatcherDto()
                {
                    TruckCount = d.Trucks.Count,
                    Name = d.Name,
                    Trucks = d.Trucks
                        .Select(t => new ExportTruckDto()
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            Make = t.MakeType.ToString()
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToArray()
                })
                .OrderByDescending(d => d.TruckCount)
                .ThenBy(t => t.Name)
                .ToArray();

            string rootName = "Despatchers";
            return XmlHelper.Serialize(despatchersAndTrucks, rootName);
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clientsAndTrucks = context.Clients
                .Where(c => c.ClientsTrucks
                    .Any(ct => ct.Truck.TankCapacity >= capacity))
                .ToArray()
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
                            CategoryType = ct.Truck.CategoryType.ToString(),
                            MakeType = ct.Truck.MakeType.ToString()
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10);

            return JsonConvert.SerializeObject(clientsAndTrucks, Formatting.Indented);
        }
    }
}
