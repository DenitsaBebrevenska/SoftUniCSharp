namespace Vehicles
{
    public class Program
    {
        static void Main()
        {
            string[] carDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carDetails[1]), double.Parse(carDetails[2]));
            string[] truckDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckDetails[1]), double.Parse(truckDetails[2]));
            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                try
                {
                    string[] commandDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string command = commandDetails[0];
                    string vehicleType = commandDetails[1];
                    double argument = double.Parse(commandDetails[2]);

                    if (command == "Drive")
                    {

                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(argument));
                        }
                        else
                        {
                            Console.WriteLine(truck.Drive(argument));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(argument);
                        }
                        else
                        {
                            truck.Refuel(argument);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
