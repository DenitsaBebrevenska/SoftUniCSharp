namespace Judge
{
	internal class Program
	{
		static void Main()
		{
			
			//<key contest < key name and value points>>
			Dictionary<string, Dictionary<string, int>> contestData = CreateContestDictionary();

			PrintContestsAndParticipants(contestData);

			PrintIndividualStandings(contestData);

		}

		static void PrintIndividualStandings(Dictionary<string, Dictionary<string, int>> contestData)
		{
			
			Console.WriteLine("Individual standings:");
			Dictionary<string, int> individualStandings = PopulateIndividualStandingsDictionary(contestData);


			int count = 0;
			foreach (var kvp in individualStandings.
				         OrderByDescending(x => x.Value).
				         ThenBy(x => x.Key))
			{
				Console.WriteLine($"{++count}. {kvp.Key} -> {kvp.Value}");
			}
		}

		static Dictionary<string, int> PopulateIndividualStandingsDictionary(Dictionary<string, Dictionary<string, int>> contestData)
		{
			Dictionary<string, int> individualStandings = new Dictionary<string, int>();

			foreach (var kvp in contestData)
			{
				foreach (var kvp2 in kvp.Value)
				{
					if (!individualStandings.ContainsKey(kvp2.Key))
					{
						individualStandings.Add(kvp2.Key, 0);
					}

					individualStandings[kvp2.Key] += kvp2.Value;
				}
			}
			return individualStandings;
		}

		static void PrintContestsAndParticipants(Dictionary<string, Dictionary<string, int>> contestData)
		{
			foreach (var kvp in contestData)
			{
				int contestantsCount = kvp.Value.Count;
				Console.WriteLine($"{kvp.Key}: {contestantsCount} participants");

				Dictionary<string, int> currentUserDetails = kvp.Value;

				int counter = 0;
				foreach (var kvp2 in currentUserDetails.OrderByDescending(x => x.Value).
					         ThenBy(x => x.Key))
				{
					
					Console.WriteLine($"{++counter}. {kvp2.Key} <::> {kvp2.Value}");
				}
			}
		}

		static Dictionary<string, Dictionary<string, int>> CreateContestDictionary()
		{
			string input;
			Dictionary<string, Dictionary<string, int>> contestData = new Dictionary<string, Dictionary<string, int>>();

			while ((input = Console.ReadLine()) != "no more time")
			{
				//"{username} -> {contest} -> {points}"
				string[] entryDetails = input.Split(" -> ");
				string username = entryDetails[0];
				string contest = entryDetails[1];
				int points = int.Parse(entryDetails[2]);

				if (!contestData.ContainsKey(contest))
				{
					contestData.Add(contest, new Dictionary<string, int>());
				}

				Dictionary<string, int> currentUserDetails = contestData[contest];

				if (!currentUserDetails.ContainsKey(username))
				{
					currentUserDetails.Add(username, points);
					continue;
				}

				if (points > currentUserDetails[username])
				{
					currentUserDetails[username] = points;
				}
			}
			return contestData;
		}
	}
}