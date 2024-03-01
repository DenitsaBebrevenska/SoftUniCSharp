namespace Ranking
	{
		internal class Program
		{
			static void Main()
			{
				string input;
				Dictionary<string, string> contest = CreateContestDictionary();

				//first key nameContestant , nested dictionary -> key is contestName, int is the points for that contest
				Dictionary<string, Dictionary<string, int>> contestants = new Dictionary<string, Dictionary<string, int>>();

				while ((input = Console.ReadLine()) != "end of submissions")
				{
					string[] submissionDetails = input.Split("=>");
					string contestName = submissionDetails[0];
					string password = submissionDetails[1];
					string username = submissionDetails[2];
					int points = int.Parse(submissionDetails[3]);

					if (!ValidateContestAndPassword(contest, contestName, password))
					{
						continue;
					}

					if (!contestants.ContainsKey(username))
					{
						contestants.Add(username, new Dictionary<string, int>());
					}

					AddContestsAndPoints(contestants, username, contestName, points);
				}

				PrintBestScoreUser(contestants);
				PrintRanking(contestants);
			}

			static bool ValidateContestAndPassword(Dictionary<string, string> contest, string contestName, string password)
			{
				if (!contest.ContainsKey(contestName))
				{
					return false;
				}

				return contest[contestName] == password;
			}

			static Dictionary<string, string> CreateContestDictionary()
			{
				Dictionary<string, string> contest = new Dictionary<string, string>();
				string input;
				while ((input = Console.ReadLine()) != "end of contests")
				{
					string[] contestDetails = input.Split(':');
					string contestName = contestDetails[0];
					string password = contestDetails[1];
					contest.Add(contestName, password);
				}
				return contest;
			}

			static void AddContestsAndPoints(Dictionary<string, Dictionary<string, int>> contestants,
				string username, string contestName, int points)
			{
				
				Dictionary<string, int> contestantTokens = contestants[username];

				if (!contestantTokens.ContainsKey(contestName))
				{
					contestantTokens.Add(contestName, 0);
				}

				if (points > contestantTokens[contestName])
				{
					contestantTokens[contestName] = points;
				}
			}

			static void PrintBestScoreUser(Dictionary<string, Dictionary<string, int>> contestants)
			{
				string bestUser = "";
				int bestScore = 0;
				foreach (var kvp in contestants)
				{
					Dictionary<string, int> currentContestant = kvp.Value;
					int currentUserScore = 0;
					foreach (var kvp2 in currentContestant)
					{
						currentUserScore += kvp2.Value;
					}

					if (currentUserScore > bestScore)
					{
						bestScore = currentUserScore;
						bestUser = kvp.Key;
					}
				}
				Console.WriteLine($"Best candidate is {bestUser} with total {bestScore} points.");
			}

			static void PrintRanking(Dictionary<string, Dictionary<string, int>> contestants)
			{
				Console.WriteLine("Ranking: ");
				foreach (var kvp in contestants.OrderBy(c => c.Key))
				{
					Console.WriteLine(kvp.Key);

					Dictionary<string, int> currentContestant = kvp.Value;
					foreach (var kvp2 in currentContestant.OrderByDescending(c => c.Value))
					{
						Console.WriteLine($"#  {kvp2.Key} -> {kvp2.Value}");
					}
				}
			}
		}
	}