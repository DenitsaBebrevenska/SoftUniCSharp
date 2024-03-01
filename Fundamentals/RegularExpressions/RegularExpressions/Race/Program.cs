using System.Text.RegularExpressions;

namespace Race
{
	internal class Program
	{
		static void Main()
		{
			string[] participants = Console.ReadLine().Split(", ");
			Dictionary<string, int> raceInformation = PopulateRaceDictionary(participants);
			string input;

			while ((input = Console.ReadLine()) != "end of race")
			{
				string name = GetParticipantName(input);

				if (!raceInformation.ContainsKey(name))
				{
					continue;
				}

				int score = GetParticipantScore(input);
				raceInformation[name] += score;
			}

			var sortedResults = raceInformation.OrderByDescending(x => x.Value).ToList();
			Console.WriteLine($"1st place: {sortedResults[0].Key}");
			Console.WriteLine($"2nd place: {sortedResults[1].Key}");
			Console.WriteLine($"3rd place: {sortedResults[2].Key}");
			
		}

		static Dictionary<string, int> PopulateRaceDictionary(string[] participants)
		{
			Dictionary<string, int> raceInformation = new Dictionary<string, int>();
			foreach (var participant in participants)
			{
				raceInformation.Add(participant, 0);
			}
			return raceInformation;
		}

		static string GetParticipantName(string input)
		{
			string regexFilterName = @"[^\W_0-9]";
			MatchCollection matchCollection = Regex.Matches(input, regexFilterName);
			string name = string.Empty;
			foreach (Match match in matchCollection)
			{
				name += match.Value;
			}
			return name;
		}

		static int GetParticipantScore(string input)
		{
			int score = 0;
			string regexFilterScore = @"[^\W_A-Za-z]";
			MatchCollection matchCollection = Regex.Matches(input, regexFilterScore);
			foreach (Match match in matchCollection)
			{
				score += int.Parse(match.Value);
			}
			return score;
		}
	}
}