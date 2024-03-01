namespace FoodShortage
{
    public class StartUp
    {
        static void Main()
        {
            int entryCount = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new();

            for (int i = 0; i < entryCount; i++)
            {
                string[] entryDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (entryDetails.Length)
                {
                    case 4:
                        buyers.Add(new Citizen(entryDetails[0], int.Parse(entryDetails[1]), entryDetails[2], entryDetails[3]));
                        break;
                    case 3:
                        buyers.Add(new Rebel(entryDetails[0], int.Parse(entryDetails[1]), entryDetails[2]));
                        break;
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                IBuyer currentBuyer = buyers.FirstOrDefault(b => b.Name == input);

                currentBuyer?.BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
