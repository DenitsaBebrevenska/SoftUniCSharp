namespace FilterByAge
{
    internal class Program
    {
        static void Main()
        {
            List<Person> people = ReadPeople();
            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
            Action<Person> printer = CreatePrinter(format);
            PrintFilteredPeople(people, filter, printer);

        }

        public static void PrintFilteredPeople(List<Person> people,
            Func<Person, bool> filter, Action<Person> printer)
        {
           List<Person> filteredPeople = people.Where(filter).ToList();
           filteredPeople.ForEach(printer);
        }


        private static Action<Person> CreatePrinter(string format)
        {
            if (format == "name")
            {
                return p => Console.WriteLine(p.Name);
            }
            else if (format == "age")
            {
                return p => Console.WriteLine(p.Age);
            }
            else if (format == "name age")
            {
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }

            throw new ArgumentException(format);
        }

        private static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            if (condition == "younger")
            {
                return p => p.Age < ageThreshold;
            }
            else if (condition == "older")
            {
                return p => p.Age >= ageThreshold;
            }

            throw new ArgumentException(condition);
        }

        static List<Person> ReadPeople()
        {
            int numberOfEntries = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                string[] personDetails = Console.ReadLine().Split(", ");
                string name = personDetails[0];
                int age = int.Parse(personDetails[1]);

                people.Add(new Person(name, age));
            }

            return people;
        }
    }

    internal class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
