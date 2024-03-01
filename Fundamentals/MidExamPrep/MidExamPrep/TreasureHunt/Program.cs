namespace TreasureHunt
{
	internal class Program
	{
		static void Main()
		{ 
			List<string> loot = Console.ReadLine().
				Split('|')
				.ToList();

			string input;
			while ((input = Console.ReadLine()) != "Yohoho!")
			{
				string[] tokens = input.Split().ToArray();
				switch (tokens[0])
				{
					case "Loot":
						AddLoot(tokens, loot);
						break;
					case "Drop":
						int index = int.Parse(tokens[1]);
						DropLoot(index, loot);
						break;
					case "Steal":
						int count = int.Parse(tokens[1]);
						StealLoot(count, loot);
						break;
				}
			}

			Console.WriteLine(loot.Count > 0 ? $"Average treasure gain: {AverageLootGain(loot):F2} pirate credits." : 
				"Failed treasure hunt.");
		}

		static void AddLoot(string[] tokens, List<string> loot)
		{
			for (int i = 1; i < tokens.Length; i++)
			{
				if (!loot.Contains(tokens[i]))
				{
					loot.Insert(0, tokens[i]);
				}
			}
		}

		static void DropLoot(int index, List<string> loot)
		{
			if (IsInListRange(index, loot))
			{
				string droppedItem = loot[index];
				loot.RemoveAt(index);
				loot.Add(droppedItem);
			}
		}

		static void StealLoot(int count, List<string> loot)
		{
			if (count > loot.Count)
			{
				count = loot.Count;
			}

			List<string> stolenLoot = loot.GetRange(loot.Count - count, count);
			Console.WriteLine(string.Join(", ", stolenLoot));
			loot.RemoveRange(loot.Count - count, count);
		}

		static double AverageLootGain(List<string> loot)
		{
			double sumLengths = 0;
			for (int i = 0; i < loot.Count; i++)
			{
				sumLengths += loot[i].Length;
			}
			return sumLengths / loot.Count;
		}

		static bool IsInListRange(int index, List<string> loot)
		{
			return index >= 0 && index < loot.Count;
		}
	}
}