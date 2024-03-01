using System.Globalization;
namespace MentorGroup
{
	internal class Program
	{
		static void Main()
		{
			List<Student> students = PopulateInitialList();

			AddComments(students);

			PrintResult(students);
		}

		static void PrintResult(List<Student> students)
		{
			foreach (Student student in students.OrderBy(s => s.Name))
			{
				Console.WriteLine(student.Name);
				Console.WriteLine("Comments:");
				foreach (string comment in student.Comments)
				{
					Console.WriteLine($"- {comment}");
				}

				Console.WriteLine("Dates attended:");
				foreach (var date in student.AttendanceDates.OrderBy(d => d.Date))
				{
					Console.WriteLine($"-- {date.Date:dd/MM/yyyy}");
				}
			}
		}

		static List<Student> PopulateInitialList()
		{
			List<Student> students = new List<Student>();
			string input;

			while ((input = Console.ReadLine()) != "end of dates")
			{
				List<string> tokens = input.Split().ToList();
				string studentName = tokens[0];
				Student student = students.FirstOrDefault(s => s.Name == studentName);

				if (student == null)
				{
					student = new Student()
					{
						Name = studentName
					};
					students.Add(student);
				}

				if (tokens.Count == 1) //if there is just a name in the input, no dates

				{
					continue;
				}

				tokens.RemoveAt(0);
				List<DateTime> attendanceDates = tokens[0].
					Split(',').
					Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", null)).ToList();

				student.AttendanceDates.AddRange(attendanceDates);
			}
			return students;
		}

		static void AddComments(List<Student> students)
		{
			string input;
			while ((input = Console.ReadLine()) != "end of comments")
			{
				List<string> commentArgs = input.Split('-').ToList();
				string commenterName = commentArgs[0];
				Student student = students.FirstOrDefault(s => s.Name == commenterName);

				if (student == null)
				{
					continue;
				}

				student.Comments.Add(commentArgs[1]);
			}
		}
	}
}
