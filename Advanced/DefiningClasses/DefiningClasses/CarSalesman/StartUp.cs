namespace CarSalesman
{
    internal class StartUp
    {
        static void Main()
        {
            List<Engine> engineList = ReadEngineListFromConsole();
            List<Car> carList = ReadCarListFromConsole(engineList);
            Console.WriteLine(string.Join(Environment.NewLine, carList));
        }

        static List<Engine> ReadEngineListFromConsole()
        {
            int engineEntryCount = int.Parse(Console.ReadLine());
            List<Engine> engineList = new();

            for (int i = 0; i < engineEntryCount; i++)
            {
                string[] engineDetails = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineDetails[0];
                int power = int.Parse(engineDetails[1]);
                string displacement;
                string efficiency;
                Engine engine = new Engine(model, power);

                if (engineDetails.Length == 3)
                {
                    if (char.IsDigit(engineDetails[2][0]))
                    {
                        displacement = engineDetails[2];
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        efficiency = engineDetails[2];
                        engine.Efficiency = efficiency;
                    }
                }

                if (engineDetails.Length == 4)
                {
                    displacement = engineDetails[2];
                    efficiency = engineDetails[3];
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }
                
                engineList.Add(engine);
            }
            return engineList;
        }
        static List<Car> ReadCarListFromConsole(List<Engine> engineList)
        {
            int carEntryCount = int.Parse(Console.ReadLine());
            List<Car> carList = new ();

            for (int i = 0; i < carEntryCount; i++)
            {
                string[] carDetails = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = carDetails[0];
                string engineModel = carDetails[1];
                string weight;
                string color;
                Engine currentCarEngine = engineList.FirstOrDefault(e => e.Model == engineModel);
                Car car = new Car(model, currentCarEngine);

                if (carDetails.Length == 3)
                {
                    if (char.IsDigit(carDetails[2][0]))
                    {
                        weight = carDetails[2];
                        car.Weight = weight;
                    }
                    else
                    {
                        color = carDetails[2];
                        car.Color = color;
                    }
                }

                if (carDetails.Length == 4)
                {
                    weight = carDetails[2];
                    color = carDetails[3];
                    car.Weight = weight;
                    car.Color = color;
                }

                carList.Add(car);
            }

            return carList;
        }
    }
}
