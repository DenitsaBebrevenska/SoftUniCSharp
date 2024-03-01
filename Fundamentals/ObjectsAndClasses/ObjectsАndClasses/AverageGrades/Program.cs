namespace AverageGrades
{
	internal class Program
	{
		static void Main()
		{
			byte numberOfLines = byte.Parse(Console.ReadLine());
			List<Student> students = new List<Student>();

			for (byte i = 0; i < numberOfLines; i++)
			{
				List<string> studentArgs = Console.ReadLine().Split().ToList();
				string studentName = studentArgs[0];
				studentArgs.Remove(studentName);
				List<double> studentGrades = studentArgs.Select(double.Parse).ToList();
				students.Add(new Student(studentName, studentGrades));
				
			}

			foreach (Student student in students.Where(s => s.AverageGrade >= 5.00).
						 OrderBy(s => s.Name).
						 ThenByDescending(s => s.AverageGrade))
			{
				Console.WriteLine($"{student.Name} -> {student.AverageGrade:F2}");
			}
		}
	}
}
