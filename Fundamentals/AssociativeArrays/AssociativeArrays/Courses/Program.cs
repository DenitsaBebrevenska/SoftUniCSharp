namespace Courses
{
	internal class Program
	{
		static void Main()
		{
			string input;
			Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

			while ((input = Console.ReadLine()) != "end")
			{
				string[] courseDetails = input.Split(" : ");
				string courseName = courseDetails[0];
				string studentName = courseDetails[1];

				if (!courses.ContainsKey(courseName))
				{
					courses.Add(courseName, new List<string>(){studentName});
					continue;
				}

				List<string> currentCourse = courses[courseName];
				currentCourse.Add(studentName);
			}

			foreach (var kvp in courses)
			{
				Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
				foreach (var value in kvp.Value)
				{
					Console.WriteLine($"-- {value}");
				}
			}
		}
	}
}