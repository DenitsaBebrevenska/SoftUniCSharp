namespace EqualityLogic
{
    public class Program
    {
        static void Main()
        {
            int numberOfEntries = int.Parse(Console.ReadLine());
            SortedSet<Person> peopleSortedSet = new ();
            HashSet<Person> peopleHashSet = new();

            for (int i = 0; i < numberOfEntries; i++)
            {
                string[] personDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personDetails[0];
                int age = int.Parse(personDetails[1]);

                Person person = new Person (name, age);
                peopleSortedSet.Add(person);
                peopleHashSet.Add(person);
            }

            Console.WriteLine(peopleHashSet.Count);
            Console.WriteLine(peopleSortedSet.Count);
        }
    }
}
