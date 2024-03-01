namespace StudentAcademy
{
	internal class Program
	{
		static void Main()
		{
			int numberOfEntries = int.Parse(Console.ReadLine());
			Dictionary<string, AverageGrade> grades = new Dictionary<string, AverageGrade>();

			for (int i = 0; i < numberOfEntries; i++)
			{
				string studentName = Console.ReadLine();
				double grade = double.Parse(Console.ReadLine());
				if (!grades.ContainsKey(studentName))
				{
					grades.Add(studentName, new AverageGrade());
				}
				AverageGrade currentGrades = grades[studentName];
				currentGrades.SumGrades += grade;
				currentGrades.Count++;
			}

			foreach (var kvp in grades
				         .Where(x => x.Value.SumGrades / x.Value.Count >= 4.5))
			{
				Console.WriteLine($"{kvp.Key} -> {kvp.Value.SumGrades / kvp.Value.Count:F2}");
			}
		}
	}
}