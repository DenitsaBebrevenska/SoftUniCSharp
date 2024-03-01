namespace SpeedRacing
{
	internal class Program
	{
		static void Main()
		{
			int carAmount = int.Parse(Console.ReadLine());
			List<Car> cars = new List<Car>();
			for (int i = 0; i < carAmount; i++)
			{
				string[] carDetails = Console.ReadLine().Split();
				string model = carDetails[0];
				double fuelAmount = double.Parse(carDetails[1]);
				double fuelPerKm = double.Parse(carDetails[2]);
				cars.Add(new Car(model, fuelAmount, fuelPerKm));
			}

			string input;
			while ((input = Console.ReadLine()) != "End")
			{
				string[] command = input.Split();
				string model = command[1];
				int traveledDistance = int.Parse(command[2]);

				Car currentCar = cars.FirstOrDefault(c => c.Model == model);
				double neededFuel = traveledDistance * currentCar.FuelConsumptionPerKm;
				if (!currentCar.FuelSuffice(neededFuel))
				{
					Console.WriteLine("Insufficient fuel for the drive");
					continue;
				}

				currentCar.TotalDistance += traveledDistance;
				currentCar.FuelAmount -= neededFuel;
			}
			PrintCars(cars);
		}

		static void PrintCars(List<Car> cars)
		{
			foreach (Car car in cars)
			{
				Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TotalDistance}");
			}
		}
	}
}