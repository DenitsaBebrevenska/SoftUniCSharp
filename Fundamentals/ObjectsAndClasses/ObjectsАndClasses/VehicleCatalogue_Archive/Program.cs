namespace VehicleCatalogue_Archive
{
	internal class Program
	{
		static void Main()
		{
			List<Vehicle> vehicleCatalog = PopulateCatalog();
			PrintVehicleDetails(vehicleCatalog);

			int carCount = vehicleCatalog.Where(v => v.Type == "Car").Count();
			int truckCount = vehicleCatalog.Where(v => v.Type == "Truck").Count();
			double averageHpCars;
			double averageHpTrucks;

			averageHpCars = carCount == 0
				? 0
				: vehicleCatalog.Where(v => v.Type == "Car").Sum(v => v.HorsePower) / carCount;
			averageHpTrucks = truckCount == 0
				? 0
				: vehicleCatalog.Where(v => v.Type == "Truck").Sum(v => v.HorsePower) / truckCount;



			Console.WriteLine($"Cars have average horsepower of: {averageHpCars:F2}.");
			Console.WriteLine($"Trucks have average horsepower of: {averageHpTrucks:F2}.");
		}

		static List<Vehicle> PopulateCatalog()
		{
			List<Vehicle> vehicleCatalog = new List<Vehicle>();
			string input;

			while ((input = Console.ReadLine()) != "End")
			{
				string[] vehicleDetails = input.Split();
				string type = vehicleDetails[0].ToLower();
				string model = vehicleDetails[1];
				string color = vehicleDetails[2];
				ushort hp = ushort.Parse(vehicleDetails[3]);

				if (type == "car")
				{
					type = "Car";
				}
				else
				{
					type = "Truck";
				}

				vehicleCatalog.Add(new Vehicle(type, model, color, hp));
			}

			return vehicleCatalog;
		}

		static void PrintVehicleDetails(List<Vehicle> vehicleCatalog)
		{
			string input;

			while ((input = Console.ReadLine()) != "Close the Catalogue")
			{
				string model = input;
				Vehicle vehicle = vehicleCatalog.FirstOrDefault(v => v.Model == model);

				Console.WriteLine(vehicle);
			}
		}
	}
}
