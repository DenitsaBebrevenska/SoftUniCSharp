namespace CountSubstringOccurrences
{
	internal class Program
	{
		static void Main()
		{
			string text = Console.ReadLine().ToLower();
			string substring = Console.ReadLine().ToLower();
			int substringLength = substring.Length;
			int occurrenceCount = 0;

			for (int i = 0; i <= text.Length - substringLength; i++)
			{
				string substringToCheck = text.Substring(i, substringLength);

				if (substringToCheck != substring)
				{
					continue;
				}

				occurrenceCount++;
			}

			Console.WriteLine(occurrenceCount);
		}
	}
}
