namespace VehicleCatalogueExercise
{
	internal class Program
	{
		static void Main()
		{
			string input;
			CatalogVehicle catalog = new CatalogVehicle();
			while ((input = Console.ReadLine()) != "End")
			{
				string[] vehicleDetails = input.Split();
				string type = char.ToUpper(vehicleDetails[0][0]) + vehicleDetails[0].Substring(1);
				string model = vehicleDetails[1];
				string color = vehicleDetails[2];
				int horsepower = int.Parse(vehicleDetails[3]);

				catalog.Vehicles.Add(new Vehicle(type, model, color, horsepower));
			}

			string catalogAction;
			while ((catalogAction = Console.ReadLine()) != "Close the Catalogue")
			{
				Vehicle wantedVehicle = catalog.Vehicles.FirstOrDefault(v => v.Model == catalogAction);
				Console.WriteLine($"Type: {wantedVehicle.Type}");
				Console.WriteLine($"Model: {wantedVehicle.Model}");
				Console.WriteLine($"Color: {wantedVehicle.Color}");
				Console.WriteLine($"Horsepower: {wantedVehicle.Horsepower}");
			}

			Console.WriteLine($"Cars have average horsepower of: {GetAverageHorsepower("Car", catalog):F2}.");
			Console.WriteLine($"Trucks have average horsepower of: {GetAverageHorsepower("Truck", catalog):F2}.");
		}

		static double GetAverageHorsepower(string type, CatalogVehicle catalog)
		{
			double totalHorsepower = 0;
			int vehicleTypeCount = 0;

			foreach (Vehicle vehicle in catalog.Vehicles.Where(v => v.Type == type))
			{
				totalHorsepower += vehicle.Horsepower;
				vehicleTypeCount++;
			}

			if (totalHorsepower == 0) //to prevent NaN
			{
				return 0;
			}

			return totalHorsepower / vehicleTypeCount;
		}
	}

}