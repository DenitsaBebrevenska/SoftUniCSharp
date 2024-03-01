namespace HandsOfCards
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<string, List<string>> playerMap = new Dictionary<string, List<string>>();
			string input;

			while ((input = Console.ReadLine()) != "JOKER")
			{
				string[] playerArgs = input.Split(": ");
				string playerName = playerArgs[0];
				string[] cardsDealt = playerArgs[1].Split(", ", StringSplitOptions.RemoveEmptyEntries);

				if (!playerMap.ContainsKey(playerName))
				{
					playerMap.Add(playerName, new List<string>());
				}

				foreach (string card in cardsDealt)
				{
					if (playerMap[playerName].Contains(card))
					{
						continue;
					}

					playerMap[playerName].Add(card);
				}
			}

			Dictionary<string, int> playerScores = new Dictionary<string, int>();

			foreach (var kvp in playerMap)
			{
				int sum = 0;

				foreach (string card in kvp.Value)
				{
					int currentScore = GetPower(card) * GetMultiplier(card);
					sum += currentScore;
				}
				playerScores.Add(kvp.Key, sum);
			}

			foreach (var kvp in playerScores)
			{
				Console.WriteLine($"{kvp.Key}: {kvp.Value}");
			}
		}

		static int GetPower(string card)
		{
			int power = 0;
			char cardSymbol = card.ToCharArray()[0];
			char cardSymbol2 = card.ToCharArray()[1];
			if (cardSymbol == '1' && cardSymbol2 == '0')
			{
				power = 10;
				return power;
			}

			if (char.IsDigit(cardSymbol))
			{
				power = cardSymbol - '0';
			}
			else
				power = cardSymbol switch
				{
					'J' => 11,
					'Q' => 12,
					'K' => 13,
					'A' => 14,
					_ => power
				};

			return power;
		}

		static int GetMultiplier(string card)
		{
			int multiplier = 0;
			char cardSymbol = card.ToCharArray()[1];

			if (cardSymbol == '0')
			{
				cardSymbol = card.ToCharArray()[2];
			}

			multiplier = cardSymbol switch
			{
				'S' => 4,
				'H' => 3,
				'D' => 2,
				'C' => 1,
				_ => multiplier
			};

			return multiplier;
		}
	}
}
