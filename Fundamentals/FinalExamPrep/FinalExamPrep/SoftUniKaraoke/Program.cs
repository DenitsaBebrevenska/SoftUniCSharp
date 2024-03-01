namespace SoftUniKaraoke
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<string, List<string>> performances = new Dictionary<string, List<string>>();
			string[] participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
			string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
			string input;

			while ((input = Console.ReadLine()) != "dawn")
			{
				string[] performanceDetails = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
				string singer = performanceDetails[0];
				string currentSong = performanceDetails[1];
				string currentAward = performanceDetails[2];

				if (!participants.Contains(singer) || !songs.Contains(currentSong))
				{
					continue;
				}

				if (!performances.ContainsKey(singer))
				{
					performances.Add(singer, new List<string>());
				}

				if (performances[singer].Contains(currentAward))
				{
					continue;
				}

				performances[singer].Add(currentAward);
			}

			if (performances.Count == 0)
			{
				Console.WriteLine("No awards");
			}
			else
			{
				foreach (var kvp in performances.OrderByDescending(x => x.Value.Count).
					         ThenBy(x => x.Key))
				{
					Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} awards");
					foreach (var award in kvp.Value.OrderBy(x => x))
					{
						Console.WriteLine($"--{award}");
					}
				}
			}
		}
	}
}
