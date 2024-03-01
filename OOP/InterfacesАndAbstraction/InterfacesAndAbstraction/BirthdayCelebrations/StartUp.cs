namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main()
        {
            List<ILiving> livingGuests = new();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] guestDetails = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (guestDetails[0])
                {
                    case "Citizen":
                        livingGuests.Add(new Citizen(guestDetails[1], int.Parse(guestDetails[2]), guestDetails[3], guestDetails[4]));
                        break;
                    case "Pet":
                        livingGuests.Add(new Pet(guestDetails[1], guestDetails[2]));
                        break;
                }
            }

            string filterYear = Console.ReadLine();

            foreach (var livingGuest in livingGuests.Where(l => l.Birthdate.EndsWith(filterYear)))
            {
                Console.WriteLine(livingGuest.Birthdate);
            }
        }
    }
}
