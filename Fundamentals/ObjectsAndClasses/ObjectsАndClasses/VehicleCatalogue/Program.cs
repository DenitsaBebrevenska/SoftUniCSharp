namespace VehicleCatalogue
{
	internal class Program
	{
		static void Main()
		{
			string input;
			CatalogVehicle catalog = new CatalogVehicle();
			while ((input = Console.ReadLine()) != "end")
			{
				string[] vehicleDetails = input.Split('/');
				string type = vehicleDetails[0];
				string brand = vehicleDetails[1];
				string model = vehicleDetails[2];
				int horsePowerOrWeight = int.Parse(vehicleDetails[3]);
				
				if (type == "Car")
				{
					Car currentCar = new Car(brand, model, horsePowerOrWeight);
					catalog.Cars.Add(currentCar);
				}
				else
				{
					Truck currentTruck = new Truck(brand, model, horsePowerOrWeight);
					catalog.Trucks.Add(currentTruck);
				}
			}

			PrintCatalog(catalog);
		}
		static void PrintCatalog(CatalogVehicle catalog)
		{
			if (catalog.Cars.Count > 0)
			{
				Console.WriteLine("Cars:");
				foreach (Car car in catalog.Cars.OrderBy(c => c.Brand))
				{
					Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
				}
			}

			if (catalog.Trucks.Count <= 0)
			{
				Console.WriteLine("Trucks:");
				foreach (Truck truck in catalog.Trucks.OrderBy(t => t.Brand))
				{
					Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
				}
			}
		}
	}
}