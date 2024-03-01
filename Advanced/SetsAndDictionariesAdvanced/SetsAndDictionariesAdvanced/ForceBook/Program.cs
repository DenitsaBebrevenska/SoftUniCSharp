namespace ForceBook
{
    internal class Program
    {
        static void Main()
        {
            string input;
            Dictionary<string, List<string>> sides = new();

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    HandleNewEntry(sides, input);
                }
                else
                {
                    HandleUserSwitchingSides(sides, input);
                }
            }

            PrintSidesMembers(sides);
        }

        static void PrintSidesMembers(Dictionary<string, List<string>> sides)
        {
            foreach (var kvp in sides.Where(x => x.Value.Count > 0).
                         OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                foreach (string user in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        static void HandleNewEntry(Dictionary<string, List<string>> sides, string input)
        {
            string[] entryDetails = input.Split(" | ");
            string forceSide = entryDetails[0];
            string forceUser = entryDetails[1];
            bool userExists = sides.Any(s => s.Value.Contains(forceUser));

            if (userExists)
            {
                return;
            }

            if (!sides.ContainsKey(forceSide))
            {
                sides.Add(forceSide, new List<string>());
            }

            sides[forceSide].Add(forceUser);
        }

        static void HandleUserSwitchingSides(Dictionary<string, List<string>> sides, string input)
        {
            string[] entryArgs = input.Split(" -> ");
            string user = entryArgs[0];
            string newSide = entryArgs[1];
            string currentSideUser = sides.FirstOrDefault(s => s.Value.Contains(user)).Key;

            if (currentSideUser != null)
            {
                sides[currentSideUser].Remove(user);
            }

            if (!sides.ContainsKey(newSide))
            {
                sides.Add(newSide, new List<string>());
            }

            sides[newSide].Add(user);
            Console.WriteLine($"{user} joins the {newSide} side!");
        }
    }
}
