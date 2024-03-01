namespace Santa_sNewList
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<string, uint> childrenMap = new Dictionary<string, uint>();
			Dictionary<string, uint> santasBag = new Dictionary<string, uint>();
			string input;

			while ((input = Console.ReadLine()) != "END")
			{
				string[] commandArgs = input.Split("->");

				if (commandArgs[0] != "Remove")
				{
					string childName = commandArgs[0];
					string presentType = commandArgs[1];
					uint presentAmount = uint.Parse(commandArgs[2]);

					if (!childrenMap.ContainsKey(childName))
					{
						childrenMap.Add(childName, 0);
					}

					childrenMap[childName] += presentAmount;

					if (!santasBag.ContainsKey(presentType))
					{
						santasBag.Add(presentType, 0);
					}
					
					santasBag[presentType] += presentAmount;

				}
				else
				{
					string naughtyChildName = commandArgs[1];
					childrenMap.Remove(naughtyChildName);
				}
			}

			Console.WriteLine("Children:");
			foreach (var kvp in childrenMap.OrderByDescending(c => c.Value).
				         ThenBy(c => c.Key))
			{
				Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
			}

			Console.WriteLine("Presents:");
			foreach (var kvp in santasBag)
			{
				Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
			}
		}
	}
}
