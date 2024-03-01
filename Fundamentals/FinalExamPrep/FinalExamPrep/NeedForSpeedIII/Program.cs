namespace NeedForSpeedIII
{
	internal class Program
	{
		static void Main()
		{
			int numberOfCars = int.Parse(Console.ReadLine());
			List<Car> cars = PopulateCarList(numberOfCars);
			string command;

			while ((command = Console.ReadLine()) != "Stop")
			{
				string[] commandDetails = command.Split(" : ");
				string action = commandDetails[0];
				string name = commandDetails[1];
				Car car = cars.FirstOrDefault(x => x.Name == name);

				switch (action)
				{
					case "Drive":
						DriveCar(commandDetails, car, cars);
						break;
					case "Refuel":
						RefuelCar(commandDetails, car);
						break;
					case "Revert":
						RevertCarMileage(commandDetails, car);
						break;
				}
			}
			Console.WriteLine(string.Join('\n', cars));
		}

		static List<Car> PopulateCarList(int numberOfCars)
		{
			List<Car> cars = new List<Car>();
			for (int i = 0; i < numberOfCars; i++)
			{
				string[] carDetails = Console.ReadLine().Split('|');
				string name = carDetails[0];
				int mileage = int.Parse(carDetails[1]);
				int fuel = int.Parse(carDetails[2]);
				cars.Add(new Car(name, mileage, fuel));
			}

			return cars;
		}

		static void DriveCar(string[] commandDetails, Car car, List<Car> cars)
		{
			int distance = int.Parse(commandDetails[2]);
			int fuel = int.Parse(commandDetails[3]);
			if (car.Fuel < fuel)
			{
				Console.WriteLine("Not enough fuel to make that ride");
				return;
			}
			car.Fuel -= fuel;
			car.Mileage += distance;
			Console.WriteLine($"{car.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
			if (car.Mileage >= 100_000)
			{
				Console.WriteLine($"Time to sell the {car.Name}!");
				cars.Remove(car);
			}
		}

		static void RefuelCar(string[] commandDetails, Car car)
		{
			int refil = int.Parse(commandDetails[2]);
			if (refil + car.Fuel > 75)
			{
				refil = 75 - car.Fuel;
			}
			car.Fuel += refil;
			Console.WriteLine($"{car.Name} refueled with {refil} liters");
		}

		static void RevertCarMileage(string[] commandDetails, Car car)
		{
			int revertedKilometers = int.Parse(commandDetails[2]);
			car.Mileage -= revertedKilometers;
			if (car.Mileage < 10_000)
			{
				car.Mileage = 10_000;
				return;
			}
			Console.WriteLine($"{car.Name} mileage decreased by {revertedKilometers} kilometers");
		}

	}
}