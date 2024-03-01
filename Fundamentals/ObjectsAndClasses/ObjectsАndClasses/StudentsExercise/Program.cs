namespace StudentsExercise
{
	internal class Program
	{
		static void Main()
		{
			int studentsCount = int.Parse(Console.ReadLine());
			List<Student> students = new List<Student>();
			for (int i = 0; i < studentsCount; i++)
			{
				string[] studentInformation = Console.ReadLine().Split();
				string firstName = studentInformation[0];
				string lastName = studentInformation[1];
				double grade = double.Parse(studentInformation[2]);
				Student currentStudent = new Student(firstName, lastName, grade);
				students.Add(currentStudent);
			}
			PrintStudentsInformation(students);
		}

		static void PrintStudentsInformation(List<Student> students)
		{
			foreach (Student student in students.OrderByDescending(s => s.Grade))
			{
				Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
			}
		}
	}

	
}