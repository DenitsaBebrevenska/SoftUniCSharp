namespace OddOccurrences
{
	internal class Program
	{
		static void Main()
		{
			string[] words = Console.ReadLine().Split().Select(w => w.ToLower()).ToArray();
			Dictionary<string, int>	wordOccurrences = new Dictionary<string, int>();
			foreach (string word in words)
			{
				if (!wordOccurrences.ContainsKey(word))
				{
					wordOccurrences.Add(word, 0);
				}

				wordOccurrences[word]++;
			}

			foreach (var kvp in wordOccurrences)
			{
				if (kvp.Value % 2 != 0)
				{
					Console.Write(kvp.Key + " ");
				}
			}
		}
	}
}