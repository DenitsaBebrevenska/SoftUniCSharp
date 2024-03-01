namespace TreasureFinder
{
	internal class Program
	{
		static void Main()
		{
			int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
			string input;

			while((input = Console.ReadLine()) != "find")
			{
				string encryptedMessage = input;
				int keyCounter = 0;
				string decryptedMessage = string.Empty;

				for (int i = 0; i < encryptedMessage.Length; i++)
				{
					decryptedMessage += (char)(encryptedMessage[i] - key[keyCounter]);
					keyCounter++;

					if (keyCounter == key.Length)
					{
						keyCounter = 0;
					}
				}

				string typeTreasure = GetTokens(decryptedMessage, '&', '&');
				string coordinates = GetTokens(decryptedMessage, '<', '>');

				Console.WriteLine($"Found {typeTreasure} at {coordinates}");
			}
		}

		static string GetTokens(string decryptedMessage, char char1, char char2)
		{
			int firstIndex = decryptedMessage.IndexOf(char1);
			int secondIndex = decryptedMessage.LastIndexOf(char2);
			return decryptedMessage.Substring(firstIndex + 1,
				secondIndex - firstIndex - 1);
		}
	}
}