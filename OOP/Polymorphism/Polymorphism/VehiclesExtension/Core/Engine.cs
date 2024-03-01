using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.IO.Interfaces;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicle>();
        }
        public void Run()
        {
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

            int commandCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }

        private void ProcessCommand()
        {
            string[] commandDetails = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == commandDetails[1]);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            double amount = double.Parse(commandDetails[2]);

            if (commandDetails[0] == "Drive")
            {
                writer.WriteLine(vehicle.Drive(amount));
            }
            else if (commandDetails[0] == "DriveEmpty")
            {
                writer.WriteLine(vehicle.Drive(amount, false));
            }
            else if (commandDetails[0] == "Refuel")
            {
                vehicle.Refuel(amount);
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] vehicleDetails = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return vehicleFactory.Create(vehicleDetails[0], double.Parse(vehicleDetails[1]),
                double.Parse(vehicleDetails[2]), double.Parse(vehicleDetails[3]));
        }
    }
}
