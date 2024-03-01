namespace ParkingLot
{
    internal class Program
    {
        static void Main()
        {
            string input;
            HashSet<string> carPlateNumbers = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] actionDetails = input.Split(", ");
                string action = actionDetails[0];
                string carPlateNumber = actionDetails[1];

                switch (action)
                {
                    case "IN":
                        carPlateNumbers.Add(carPlateNumber);
                        break;
                    case "OUT":
                        carPlateNumbers.Remove(carPlateNumber);
                        break;
                }
            }

            Console.WriteLine(carPlateNumbers.Count == 0 ? "Parking Lot is Empty" : $"{string.Join("\n", carPlateNumbers)}");
        }
    }
}
