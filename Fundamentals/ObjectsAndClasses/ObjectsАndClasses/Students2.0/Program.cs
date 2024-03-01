namespace Students2._0
{
	internal class Program
	{
		static void Main()
		{
			List<Student> students = new List<Student>();
			string input;
			while ((input = Console.ReadLine()) != "end")
			{
				string[] studentInformation = input.Split();
				string firstName = studentInformation[0];
				string lastName = studentInformation[1];
				int age = int.Parse(studentInformation[2]);
				string hometown = studentInformation[3];

				Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
				if (student == null)
				{
					students.Add(new Student()
					{
						FirstName = firstName,
						LastName = lastName,
						Age = age,
						Hometown = hometown
					});
				}
				else
				{
					student.Age = age;
					student.Hometown = hometown;
				}

			}
			string townFilter = Console.ReadLine();
			PrintFilteredStudents(students, townFilter);
			
		}
		static void PrintFilteredStudents(List<Student> students, string townFilter)
		{
			foreach (Student student in students.Where(s => s.Hometown == townFilter))
			{
				Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
			}
		}

		
	}
}