namespace OpinionPoll
{
    public class StartUp
    {
        static void Main()
        {
            int entryCount = int.Parse(Console.ReadLine());
            List<Person> people = new();

            for (int i = 0; i < entryCount; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                people.Add(new Person(name, age));
            }

            List<Person> filteredList = people.Where(p => p.Age > 30)
                .OrderBy(p => p.Name).
                ToList();

            foreach (var person in filteredList.Where(p => p.Age > 30)
                         .OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
