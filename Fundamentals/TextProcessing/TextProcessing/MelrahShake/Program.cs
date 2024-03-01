namespace MelrahShake
{
	internal class Program
	{
		static void Main()
		{
			string text = Console.ReadLine();
			string pattern = Console.ReadLine();
			
			bool canShake = true;

			while (canShake)
			{
				int indexFirstOccurrence = text.IndexOf(pattern);
				int indexLastOccurrence = text.LastIndexOf(pattern);

				if (indexFirstOccurrence == indexLastOccurrence)
				{
					canShake = false;
					Console.WriteLine("No shake.");
				}
				else
				{
					text = text.Remove(indexLastOccurrence, pattern.Length);
					text = text.Remove(indexFirstOccurrence, pattern.Length);
					Console.WriteLine("Shaked it.");
					int indexToRemove = pattern.Length / 2;
					pattern = pattern.Remove(indexToRemove, 1);

					if (pattern == string.Empty)
					{
						canShake = false;
						Console.WriteLine("No shake.");
					}
				}
			}

			Console.WriteLine(text);
		}
	}
}
