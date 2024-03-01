namespace CountCharsInAString
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			Dictionary<char, int> chars = new Dictionary<char, int>();

			foreach (char character in input.Where(c => c != ' '))
			{
				if (!chars.ContainsKey(character))
				{
					chars.Add(character, 0);
				}

				chars[character]++;
			}

			foreach (var kvp in chars)
			{
				Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
			}
		}
	}
}