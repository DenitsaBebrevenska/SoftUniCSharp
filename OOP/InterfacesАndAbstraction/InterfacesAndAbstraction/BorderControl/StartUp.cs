namespace BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            string input;
            List<IIdentifiable> entrants = new();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] entrantDetails = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (entrantDetails.Length == 3)
                {
                    entrants.Add(new Citizen(entrantDetails[0], int.Parse(entrantDetails[1]), entrantDetails[2]));
                }
                else
                {
                    entrants.Add(new Robot(entrantDetails[0], entrantDetails[1]));
                }
            }

            string fakeFilter = Console.ReadLine();

            foreach (var entrant in entrants)
            {
                if (!entrant.HasValidId(fakeFilter))
                {
                    Console.WriteLine(entrant.Id);
                }
            }
        }
    }
}
