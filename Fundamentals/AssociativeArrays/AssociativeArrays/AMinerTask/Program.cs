namespace AMinerTask
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<string, int> materials = new Dictionary<string, int>();
			while (true)
			{
				string key = Console.ReadLine();
				if (key == "stop")
				{
					break;
				}

				int value = int.Parse(Console.ReadLine());

				if (!materials.ContainsKey(key))
				{
					materials.Add(key, 0);
				}

				materials[key] += value;
			}

			foreach (var kvp in materials)
			{
				Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
			}
			
		}
	}
}