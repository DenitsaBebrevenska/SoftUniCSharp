namespace OldestFamilyMember
{
	internal class Program
	{
		static void Main()
		{
			int peopleCount = int.Parse(Console.ReadLine());
			Family family = new Family();
			for (int i = 0; i < peopleCount; i++)
			{
				string[] personDetails = Console.ReadLine().Split();
				string name = personDetails[0];
				int age = int.Parse(personDetails[1]);
				Family.AddPerson(new Person(name, age));
			}

			Person oldestPerson = Family.GetOldestPerson();
			Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
		}
	}
}