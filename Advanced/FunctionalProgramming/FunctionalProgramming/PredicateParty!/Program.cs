namespace PredicateParty_
{
    internal class Program
    {
        static void Main()
        {
            Func<List<string>, Predicate<string>, string, List<string>> manipulateList = (list, condition, action) =>
            {
                List<string> newList = new List<string>();

                foreach (string name in list)
                {
                    if (condition(name))
                    {
                        if (action == "Remove")
                        {
                            continue;
                        }

                        if (action == "Double")
                        {
                            newList.Add(name);
                            newList.Add(name);
                        }

                        continue;
                    }

                    //if the condition is not satisfied just add the new name on the list
                    newList.Add(name);
                }
                return newList;
            };

            List<string> guestList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] commandArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];
                string condition = commandArgs[1];
                string filter = commandArgs[2];
                Predicate<string> conditionPredicate = name => true;

                if (condition == "StartsWith")
                {
                    conditionPredicate = name => name.Substring(0, filter.Length) == filter;
                }
                else if (condition == "EndsWith")
                {
                    conditionPredicate = name => name.Substring(name.Length - filter.Length) == filter;
                }
                else if (condition == "Length")
                {
                    conditionPredicate = name => name.Length == int.Parse(filter);
                }

                guestList = manipulateList(guestList, conditionPredicate, command);
            }

            Console.WriteLine(guestList.Count > 0 ? $"{string.Join(", ", guestList)} are going to the party!" : "Nobody is going to the party!");
        }
    }
}
