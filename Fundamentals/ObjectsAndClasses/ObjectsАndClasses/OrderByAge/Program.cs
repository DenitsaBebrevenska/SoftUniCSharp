namespace OrderByAge
{
	internal class Program
	{
		static void Main()
		{
			string input;
			List<Person> people = new List<Person>();

			while ((input = Console.ReadLine()) != "End")
			{
				string[] personDetails = input.Split();
				string name = personDetails[0];
				string id = personDetails[1];
				int age = int.Parse(personDetails[2]);
				Person currentPerson = new Person(name, id, age);

				if (people.Exists(p => p.ID == id))
				{
					int index = people.FindIndex(p => p.ID == id);
					people[index] = currentPerson;
					continue;
				}
				people.Add(currentPerson);
			}

			foreach (Person person in people.OrderBy(p => p.Age))
			{
				Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
			}
		}
	}
}