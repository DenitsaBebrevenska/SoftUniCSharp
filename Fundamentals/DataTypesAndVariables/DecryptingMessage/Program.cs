namespace DecryptingMessage
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int key = int.Parse(Console.ReadLine());
			int n = int.Parse(Console.ReadLine());

			string decodedMessage = string.Empty;
			for (int i = 1; i <= n ; i++)
			{
				string input = Console.ReadLine();
				int currentCharValue = input[0];
				int decodedCharValue = currentCharValue + key;
				char currentChar = (char)decodedCharValue;
				decodedMessage += currentChar;
			}
            Console.WriteLine(decodedMessage);
        }
	}
}