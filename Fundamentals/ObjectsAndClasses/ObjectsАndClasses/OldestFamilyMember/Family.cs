using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestFamilyMember
{
	internal class Family
	{
		public static List<Person> People;

		public Family()
		{
			People = new List<Person>();
		}
		public static void AddPerson(Person person)
		{
			People.Add(person);
		}

		public static Person GetOldestPerson()
		{
			Person oldestPerson = People.OrderByDescending(p => p.Age).First();
			return oldestPerson;
		}
	}
}
