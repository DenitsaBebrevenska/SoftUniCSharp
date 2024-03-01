namespace SpeedRacing
{
    public class StartUp
    {
        static void Main()
        {
            List<Car> cars = new();
            PopulateCarList(cars);
            ManipulateCars(cars);
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private static void ManipulateCars(List<Car> cars)
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = commandArgs[1];
                int distance = int.Parse(commandArgs[2]);

                Car currentCar = cars.FirstOrDefault(c => c.Model == carModel);
                currentCar.Drive(distance);
            }
        }

        private static void PopulateCarList(List<Car> cars)
        {
            int entryCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < entryCount; i++)
            {
                string[] carDetails = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carDetails[0];
                double fuelAmount = double.Parse(carDetails[1]);
                double fuelPerKm = double.Parse(carDetails[2]);
                cars.Add(new Car(model, fuelAmount, fuelPerKm));
            }
        }
    }
}
