using System.Linq;

namespace ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main()
        {
            List<string> invitationList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, string, Predicate<string>> predicateGenerator = (type, parameter) =>
            {
                Predicate<string> generatedPredicate = s => true;

                if (type == "Starts with")
                {
                    generatedPredicate = s => s.Substring(0, parameter.Length) == parameter;
                }
                else if (type == "Ends with")
                {
                    generatedPredicate = s => s.Substring(s.Length - parameter.Length) == parameter;
                }
                else if (type == "Length")
                {
                    generatedPredicate = s => s.Length == int.Parse(parameter);
                }
                else if (type == "Contains")
                {
                    generatedPredicate = s => s.Contains(parameter);
                }

                return generatedPredicate;
            };

            Dictionary<string, Predicate<string>> filterList = new();

            string input;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] filterArgs = input.Split(';');
                string command = filterArgs[0];
                string type = filterArgs[1];
                string parameter = filterArgs[2];
                string filterName = type + parameter;

                if (command == "Add filter")
                {
                    filterList.Add(filterName, predicateGenerator(type, parameter));
                    continue;
                }
                
                if (command == "Remove filter")
                {
                    //you won't be asked to remove a non-existent filter
                    filterList.Remove(filterName);
                }
            }

            FilterList(invitationList, filterList);
            Console.WriteLine(string.Join(' ', invitationList));
        }

        static void FilterList(List<string> invitationList, Dictionary<string, Predicate<string>> filterList)
        {
            for (int i = 0; i < invitationList.Count; i++)
            {
                foreach (var predicate in filterList.Values)
                {
                    if (predicate(invitationList[i]))
                    {
                        invitationList.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }
        }
    }
}
