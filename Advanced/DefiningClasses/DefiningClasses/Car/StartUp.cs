namespace CarManufacturer
{
    public class StartUp
    {
        internal static List<Tire[]> TireList = new();
        internal static List<Engine> Engines = new();
        internal static List<Car> Cars = new();
        static void Main()
        {
            PopulateTiresList();
            PopulateEngineList();
            PopulateCarList();

            List<Car> specialCars = Cars.Where(c => c.Year >= 2017
                                   && c.Engine.HorsePower > 330
                                   && c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10)
                .ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}\n" +
                                  $"Model: {car.Model}\n" +
                                  $"Year: {car.Year}\n" +
                                  $"HorsePowers: {car.Engine.HorsePower}\n" +
                                  $"FuelQuantity: {car.FuelQuantity}");
            }
        }

        static void PopulateTiresList()
        {
            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                double[] tireArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                Tire[] tires = new Tire[4];
                int indexTires = 0;

                for (int j = 0; j < tireArgs.Length; j += 2, indexTires++)
                {
                    Tire tire = new Tire((int)tireArgs[j], tireArgs[j + 1]);
                    tires[indexTires] = tire;
                }

                TireList.Add(tires);
            }
        }

        static void PopulateEngineList()
        {
            string input;
            while ((input = Console.ReadLine()) != "Engines done")
            {
                double[] engineArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                Engines.Add(new Engine((int)engineArgs[0], engineArgs[1]));
            }

        }

        static void PopulateCarList()
        {
            string input;
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = carArgs[0];
                string model = carArgs[1];
                int year = int.Parse(carArgs[2]);
                double fuelQuantity = double.Parse(carArgs[3]);
                double fuelConsumption = double.Parse(carArgs[4]);
                Engine engine = Engines[int.Parse(carArgs[5])];
                Tire[] tires = TireList[int.Parse(carArgs[6])];

                Cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires));
            }
        }
    }
}
