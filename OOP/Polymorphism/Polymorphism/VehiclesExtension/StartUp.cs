using VehiclesExtension.Core;
using VehiclesExtension.Factories;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.IO;
using VehiclesExtension.IO.Interfaces;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory factory = new VehicleFactory();
            Engine engine = new Engine(reader, writer, factory);
            engine.Run();
        }
    }
}
