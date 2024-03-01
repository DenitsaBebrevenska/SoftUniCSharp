namespace TheImitationGame
{
	internal class Program
	{
		static void Main()
		{
			string encryptedMessage = Console.ReadLine();
			string command;

			while ((command = Console.ReadLine()) != "Decode")
			{
				string[] tokens = command.Split('|');
				switch (tokens[0])
				{
					case "Move":
						int numberOfLetters = int.Parse(tokens[1]);
						string lettersToMove = encryptedMessage.Substring(0, numberOfLetters);
						encryptedMessage = encryptedMessage.Substring(numberOfLetters) + lettersToMove;
						break;
					case "Insert":
						int index = int.Parse(tokens[1]);
						string value = tokens[2];
						encryptedMessage = encryptedMessage.Insert(index, value);
						break;
					case "ChangeAll":
						string substring = tokens[1];
						string replacement = tokens[2];
						encryptedMessage = encryptedMessage.Replace(substring, replacement);
						break;
				}
			}

			Console.WriteLine($"The decrypted message is: {encryptedMessage}");
		}
	}
}