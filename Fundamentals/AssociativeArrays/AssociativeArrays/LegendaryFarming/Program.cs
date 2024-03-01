namespace LegendaryFarming
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<string, uint> materials = new Dictionary<string, uint>();
			SortedDictionary<string, uint> junk = new SortedDictionary<string, uint>();

			materials.Add("motes", 0);
			materials.Add("shards", 0);
			materials.Add("fragments", 0);
			string legendaryName = string.Empty;
			bool legengaryObtained = false;

			while (!legengaryObtained)
			{
				string[] input = Console.ReadLine().Split();

				for (int i = 1; i < input.Length ; i += 2)
				{
					string item = input[i].ToLower();
					uint quantity = uint.Parse(input[i - 1]);

					if (item == "motes" || item == "shards" || item == "fragments")
					{
						materials[item] += quantity;

						if (IsEnough(materials[item]))
						{
							if (item == "motes")
							{
								legendaryName = "Dragonwrath";

							}
							else if (item == "shards")
							{
								legendaryName = "Shadowmourne";
							}
							else if (item == "fragments")
							{
								legendaryName = "Valanyr";
							}

							materials[item] -= 250;
							legengaryObtained = true;
							break;
						}
					}
					else
					{
						if (!junk.ContainsKey(item))
						{
							junk.Add(item, 0);
						}

						junk[item] += quantity;
					}
				}
			}

			Console.WriteLine($"{legendaryName} obtained!");

			foreach (var kvp in materials.OrderByDescending(x => x.Value).
				         ThenBy(x => x.Key))
			{
				Console.WriteLine($"{kvp.Key}: {kvp.Value}");
			}

			foreach (var kvp in junk)
			{
				Console.WriteLine($"{kvp.Key}: {kvp.Value}");
			}
		}

		static bool IsEnough(uint quantity)
		{
			return quantity >= 250;
		}
	}
}
