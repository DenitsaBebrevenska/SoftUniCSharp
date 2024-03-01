namespace Students
{
	internal class Program
	{
		static void Main()
		{
			List<Student> students = new List<Student>();
			string input;
			while ((input = Console.ReadLine()) != "end")
			{
				string[] studentInfo = input.Split();
				string firstName = studentInfo[0];
				string lastName = studentInfo[1];
				int age = int.Parse(studentInfo[2]);
				string hometown = studentInfo[3];

				Student currentStudent = new Student()
				{
					FirstName = firstName,
					LastName = lastName,
					Age = age,
					Hometown = hometown
				};

				students.Add(currentStudent);
			}
			string filterHometown = Console.ReadLine();

			foreach (Student student in students.Where(s => s.Hometown == filterHometown))
			{
				Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
			}
		}
	}

}
