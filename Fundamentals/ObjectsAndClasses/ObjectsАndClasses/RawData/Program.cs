namespace RawData
{
	internal class Program
	{
		static void Main()
		{
			int carsAmount = int.Parse(Console.ReadLine());
			List<Car> cars = new List<Car>();
			for (int i = 0; i < carsAmount; i++)
			{
				string[] carDetails = Console.ReadLine().Split();
				string model = carDetails[0];
				int engineSpeed = int.Parse(carDetails[1]);
				int enginePower = int.Parse(carDetails[2]);
				int cargoWeigh = int.Parse(carDetails[3]);
				string cargoType = carDetails[4];
				
				cars.Add(new Car(model, new Engine(engineSpeed, enginePower), new Cargo(cargoWeigh, cargoType)));
			}
			string state = Console.ReadLine();
			if (state == "fragile")
			{
				foreach (Car car in cars.Where(c => c.CarCargo.Type == "fragile" && c.CarCargo.Weight < 1000))
				{
					Console.WriteLine(car.Model);
				}
			}
			else //flamable
			{
				foreach (Car car in cars.Where(c => c.CarCargo.Type == "flamable" && c.CarEngine.Power > 250))
				{
					Console.WriteLine(car.Model);
				}
			}
		}
	}
}