namespace RawData
{
    public class StartUp
    {
        static Func<string, List<Car>, List<Car>> getFilteredList = (filter, carList) =>
        {
            List<Car> filteredCars = new();

            if (filter == "fragile")
            {
                filteredCars = carList.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(tire => tire.Pressure < 1.0)).ToList();
            }
            else //flammable
            {
                filteredCars = carList.Where(c => c.Cargo.Type == filter && c.Engine.Power > 250).ToList();
            }
            return filteredCars;
        };
        static void Main()
        {
            List<Car> cars = ReadCarListFromConsole();
            string filterCargo = Console.ReadLine();
            List<Car> filteredCars = getFilteredList(filterCargo, cars);

            foreach (var car in filteredCars)
            {
                Console.WriteLine(car);
            }
        }

        static List<Car> ReadCarListFromConsole()
        {
            List<Car> cars = new();
            int entryCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < entryCount; i++)
            {
                string[] carDetails = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carDetails[0];
                int engineSpeed = int.Parse(carDetails[1]);
                int enginePower = int.Parse(carDetails[2]);
                int cargoWeight = int.Parse(carDetails[3]);
                string cargoType = carDetails[4];
                double tire1Pressure = double.Parse(carDetails[5]);
                int tire1Age = int.Parse(carDetails[6]);
                double tire2Pressure = double.Parse(carDetails[7]);
                int tire2Age = int.Parse(carDetails[8]);
                double tire3Pressure = double.Parse(carDetails[9]);
                int tire3Age = int.Parse(carDetails[10]);
                double tire4Pressure = double.Parse(carDetails[11]);
                int tire4Age = int.Parse(carDetails[12]);
                cars.Add(new Car(model,
                    new Engine(engineSpeed, enginePower),
                    new Cargo(cargoType, cargoWeight),
                    new Tire[4]
                    {
                        new Tire(tire1Age, tire1Pressure),
                        new Tire(tire2Age, tire2Pressure),
                        new Tire(tire3Age, tire3Pressure),
                        new Tire(tire4Age, tire4Pressure)
                    }));
            }

            return cars;
        }
    }
}
