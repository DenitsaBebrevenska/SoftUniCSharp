namespace SoftUniParty
{
    internal class Program
    {
        static void Main()
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();
            bool guestsLeaving = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "PARTY")
                {
                    guestsLeaving = true;
                }

                if (input == "END")
                {
                    break;
                }

                if (!guestsLeaving)
                {
                   AddGuests(input, vipGuests, regularGuests);
                    continue;
                }

                RemoveGuests(input, vipGuests, regularGuests);
            }

            Console.WriteLine(vipGuests.Count + regularGuests.Count);
            PrintRemainingGuests(vipGuests, regularGuests);
            
        }

        static void PrintRemainingGuests(HashSet<string> vipGuests, HashSet<string> regularGuests)
        {
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }

        static void AddGuests(string input, HashSet<string> vipGuests, HashSet<string> regularGuests)
        {
            if (char.IsDigit(input[0]))
            {
                vipGuests.Add(input);
            }
            else
            {
                regularGuests.Add(input);
            }
        }

        static void RemoveGuests(string input, HashSet<string> vipGuests, HashSet<string> regularGuests)
        {
            if (char.IsDigit(input[0]))
            {
                vipGuests.Remove(input);
            }
            else
            {
                regularGuests.Remove(input);
            }
        }
    }
}
