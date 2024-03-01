namespace MOBAChallenger
{
	internal class Program
	{
		static void Main()
		{
			string input;
			Dictionary<string, Dictionary<string, int>> tier = new Dictionary<string, Dictionary<string, int>>();

			while ((input = Console.ReadLine()) != "Season end")
			{
				string[] tokens = input.Split();

				if (tokens.Length == 5)
				{
					UpdateTier(tokens, tier);
				}
				else
				{
					Duel(tokens, tier);
				}
			}

			PrintTierWinners(tier);
		}

		static void PrintTierWinners(Dictionary<string, Dictionary<string, int>> tier)
		{
			foreach (var kvp in tier.
				         OrderByDescending(x => x.Value.Values.Sum()).
				         ThenBy(x => x.Key))
			{
				int sumSkillPlayer = kvp.Value.Values.Sum();
				Console.WriteLine($"{kvp.Key}: {sumSkillPlayer} skill");

				Dictionary<string, int> currentPlayer = tier[kvp.Key];
				foreach (var kvp2 in currentPlayer.OrderByDescending(x => x.Value).
					         ThenBy(x => x.Key))
				{
					Console.WriteLine($"- {kvp2.Key} <::> {kvp2.Value}");
				}
			}
		}

		static void Duel(string[] tokens, Dictionary<string, Dictionary<string, int>> tier)
		{
			string player1 = tokens[0];
			string player2 = tokens[2];
			if (!tier.ContainsKey(player1) || !tier.ContainsKey(player2))
			{
				return;
			}

			if (!PlayersSharePosition(tier, player1, player2))
			{
				return;
			}

			string winner = GetWinner(tier, player1, player2);

			if (winner == null)
			{
				return;
			}

			if (winner == "player1")
			{
				tier.Remove(player2);
				return;
			}
			tier.Remove(player1);
		}

		static void UpdateTier(string[] tokens, Dictionary<string, Dictionary<string, int>> tier)
		{
			string player = tokens[0];
			string position = tokens[2];
			int skill = int.Parse(tokens[4]);
					
			if (!tier.ContainsKey(player))
			{
				tier.Add(player, new Dictionary<string, int>());
			}

			Dictionary<string, int> currentPlayerTokens = tier[player];
			if (!currentPlayerTokens.ContainsKey(position))
			{
				currentPlayerTokens.Add(position, skill);
				return;
			}

			if (skill > currentPlayerTokens[position])
			{
				currentPlayerTokens[position] = skill;
			}
		}

		static bool PlayersSharePosition(Dictionary<string, Dictionary<string, int>> tier, string player1, string player2)
		{
			Dictionary<string, int> player1Statistics = tier[player1];
			Dictionary<string, int> player2Statistics = tier[player2];

			foreach (var kvp in player1Statistics)
			{
				foreach (var kvp2 in player2Statistics)
				{
					if (kvp.Key == kvp2.Key)
					{
						return true;
					}
				}
			}
			return false;
		}

		static string GetWinner(Dictionary<string, Dictionary<string, int>> tier, string player1, string player2)
		{
			Dictionary<string, int> player1Statistics = tier[player1];
			Dictionary<string, int> player2Statistics = tier[player2];

			int player1Skill = player1Statistics.Sum(x => x.Value);
			int player2Skill = player2Statistics.Sum(y => y.Value);

			if (player1Skill > player2Skill)
			{
				return "player1";
			}
			else if (player1Skill < player2Skill)
			{
				return "player2";
			}

			return null;
		}
	}
}