namespace SoftUniCoursePlanning
{
	internal class Program
	{
		static void Main()
		{
			List<string> schedule = Console.ReadLine().
				Split(", ").
				ToList();

			string action;
			while ((action = Console.ReadLine()) != "course start")
			{
				string[] tokens = action.Split(':');

				if (tokens[0] == "Add" && !schedule.Contains(tokens[1]))
				{
					schedule.Add(tokens[1]);
				}
				else if (tokens[0] == "Insert" && !schedule.Contains(tokens[1]))
				{
					schedule.Insert(int.Parse(tokens[2]), tokens[1]);
				}
				else if (tokens[0] == "Remove" && schedule.Contains(tokens[1]))
				{
					Remove(schedule, tokens[1]);
				}
				else if (tokens[0] == "Swap" && schedule.Contains(tokens[1]) && schedule.Contains(tokens[2]))
				{
					Swap(schedule, tokens[1], tokens[2]);
				}
				else if (tokens[0] == "Exercise")
				{
					AddExercise(schedule, tokens[1]);
				}
			}

			for (int i = 0; i < schedule.Count; i++)
			{
				Console.WriteLine($"{i + 1}.{schedule[i]}");
			}
		}
		static void Remove(List<string> schedule, string lessonName)
		{
			schedule.Remove(lessonName);
			string exerciseName = $"{lessonName}-Exercise";
			if (schedule.Contains(exerciseName))
			{
				schedule.Remove(exerciseName);
			}
		}
		static void Swap(List<string> schedule, string lessonName1, string lessonName2)
		{
			for (int i = 0; i < schedule.Count; i++)
			{
				if (schedule[i] == lessonName1)
				{
					schedule[i] = lessonName2;
				}
				else if (schedule[i] == lessonName2)
				{
					schedule[i] = lessonName1;
				}
			}
			if (schedule.Contains($"{lessonName1}-Exercise"))
			{
				schedule.Remove($"{lessonName1}-Exercise");
				schedule.Insert(schedule.IndexOf(lessonName1) + 1, $"{lessonName1}-Exercise");
			}
			else if (schedule.Contains($"{lessonName2}-Exercise"))
			{
				schedule.Remove($"{lessonName2}-Exercise");
				schedule.Insert(schedule.IndexOf(lessonName2) + 1, $"{lessonName2}-Exercise");
			}
		}
		static void AddExercise(List<string> schedule, string lessonName)
		{ 
			string exerciseName = $"{lessonName}-Exercise";
			if (schedule.Contains(lessonName) && !schedule.Contains(exerciseName))
			{
				int indexLesson = schedule.IndexOf(lessonName);
				schedule.Insert(++indexLesson, exerciseName);
			}
			else if (!schedule.Contains(lessonName))
			{
				schedule.Add(lessonName);
				schedule.Add(exerciseName);
			}

		}
	}
}