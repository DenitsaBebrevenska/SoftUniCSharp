namespace ComparingObjects
{
    internal class Program
    {
        static void Main()
        {
            List<Person> people = new();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] personDetails = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(personDetails[0], int.Parse(personDetails[1]), personDetails[2]));
            }

            int personIndex = int.Parse(Console.ReadLine()) - 1;
            Person personToCompareTo = people[personIndex];

            int matches = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].CompareTo(personToCompareTo) == 0)
                {
                    matches++;
                }
            }

            Console.WriteLine(matches == 1 ? "No matches" : $"{matches} {people.Count - matches} {people.Count}");
        }
    }
}
