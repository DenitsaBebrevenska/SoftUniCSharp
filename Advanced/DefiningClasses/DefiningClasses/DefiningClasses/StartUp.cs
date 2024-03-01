namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int entryCount = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < entryCount; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                family.AddMember(new Person(name, age));
            }

            Person oldestFamilyMember = family.GetOldestMember();
            Console.WriteLine($"{oldestFamilyMember.Name} {oldestFamilyMember.Age}");
        }
    }
}
