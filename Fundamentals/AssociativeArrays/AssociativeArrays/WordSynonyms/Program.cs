namespace WordSynonyms
{
	internal class Program
	{
		static void Main()
		{
			int numberOfWords = int.Parse(Console.ReadLine());
			Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();
			for (int i = 0; i < numberOfWords; i++)
			{
				string key = Console.ReadLine();
				string value = Console.ReadLine();

				if (!synonyms.ContainsKey(key))
				{
					synonyms.Add(key, new List<string>());
				}
				synonyms[key].Add(value);
			}

			foreach (var kvp in synonyms)
			{
				Console.WriteLine($"{kvp.Key} - {string.Join(", ",kvp.Value)}");
			}
		}
	}
}