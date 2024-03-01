namespace StudentGroups
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<Town, List<Student>> townStudents = PopulateInitialDictionary();

			townStudents = OrderStudents(townStudents);
			
			List<Town> townList = new List<Town>();
			int groupsFormed = 0;

			foreach (var kvp in townStudents.OrderBy(x => x.Key.Name))
			{
				Town t = kvp.Key;
				townList.Add(t);

				if (t.Seats >= kvp.Value.Count)
				{
					t.GroupsOfStudents.Add(new Group()
					{
						Students = kvp.Value
					});
					groupsFormed++;
					continue;
				}
				
				int studentCount = kvp.Value.Count;
				

				while (studentCount > 0)
				{
					int studentsToRemove = 0;

					if (studentCount >= t.Seats)
					{
						studentsToRemove = t.Seats;
					}
					else
					{
						studentsToRemove = kvp.Value.Count;
					}

					t.GroupsOfStudents.Add(new Group()
					{
						Students = kvp.Value.Take(studentsToRemove).ToList()
					});
					groupsFormed++;
					studentCount -= studentsToRemove;
					kvp.Value.RemoveRange(0, studentsToRemove);
				}

			}

			Console.WriteLine($"Created {groupsFormed} groups in {townList.Count} towns:");
			foreach (Town t in townList)
			{
				foreach (Group group in t.GroupsOfStudents)
				{
					List<string> emails = new List<string>();

					foreach (Student student in group.Students)
					{
						emails.Add(student.Email);
					}

					Console.WriteLine($"{t.Name} => {string.Join(", ", emails)}");
				}
			}
		}

		static Dictionary<Town, List<Student>> PopulateInitialDictionary()
		{
			Dictionary<Town, List<Student>> townStudents = new Dictionary<Town, List<Student>>();
			string input;
			Town town = new Town();

			while ((input = Console.ReadLine()) != "End")
			{
				
				if (!input.Contains('|'))
				{
					string[] townArgs = input.Split(new char[]{'=','>'}, StringSplitOptions.RemoveEmptyEntries);
					string townName = townArgs[0].Trim();
					string[] seatArgs = townArgs[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
					int seatAmount = int.Parse(seatArgs[0]);
					town = new Town()
					{
						Name = townName,
						Seats = seatAmount
					};
					townStudents.Add(town, new List<Student>());
				}
				else
				{
					string[] studentArgs = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
					string studentName = studentArgs[0].Trim();
					string studentEmail = studentArgs[1].Trim();
					string registration = studentArgs[2].Trim();
					DateTime studentRegistration = DateTime.ParseExact(registration, "d-MMM-yyyy", null);

					townStudents[town].Add(new Student(studentName, studentEmail, studentRegistration));
				}
			}
			return townStudents;
		}

		static Dictionary<Town, List<Student>> OrderStudents(Dictionary<Town, List<Student>> townStudents)
		{
			Dictionary<Town, List<Student>> orderedStudentsTown = new Dictionary<Town, List<Student>>();
			foreach (var kvp in townStudents)
			{
				
				List<Student> students = kvp.Value.OrderBy(s => s.DateOfRegistration).
					ThenBy(s => s.Name).
					ThenBy(s => s.Email).
					ToList();
				orderedStudentsTown.Add(kvp.Key, students);
			}

			return orderedStudentsTown;
		}
	}

	internal class Student
	{
		public string Name { get; set; }

		public string Email { get; set; }

		public DateTime DateOfRegistration { get; set; }

		public Student()
		{
			
		}

		public Student(string name, string email, DateTime registrationDate)
		{
				Name = name;
				Email = email;
				DateOfRegistration = registrationDate;
		}
	}

	internal class Town
	{
		public string Name { get; set; }

		public int Seats { get; set; }

		public List<Group> GroupsOfStudents { get; set; }

		public Town()
		{
			GroupsOfStudents = new List<Group>();
		}
	}

	internal class Group
	{
		public List<Student> Students { get; set; }

		public Group()
		{
			Students = new List<Student>();
		}
	}
}
