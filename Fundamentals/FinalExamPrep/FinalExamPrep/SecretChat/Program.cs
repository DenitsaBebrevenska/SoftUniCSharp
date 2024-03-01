namespace SecretChat
{
	internal class Program
	{
		static void Main()
		{
			string concealedMessage = Console.ReadLine();
			string input;

			while ((input = Console.ReadLine()) != "Reveal")
			{
				string[] commandDetails = input.Split(":|:");
				switch (commandDetails[0])
				{
					case "InsertSpace":
						int index = int.Parse(commandDetails[1]);
						concealedMessage = concealedMessage.Insert(index, " ");
						break;
					case "Reverse":
						string substring = commandDetails[1];
						if (!concealedMessage.Contains(substring))
						{
							Console.WriteLine("error");
							continue;
						}
						int indexOfSubstring = concealedMessage.IndexOf(substring);
						concealedMessage = concealedMessage.Remove(indexOfSubstring, substring.Length);
						string reversedSubstring = new string(substring.ToCharArray().Reverse().ToArray());
						concealedMessage += reversedSubstring;
							break;
					case "ChangeAll":
						concealedMessage = concealedMessage.Replace(commandDetails[1], commandDetails[2]);
						break;
				}

				Console.WriteLine(concealedMessage);
			}

			Console.WriteLine($"You have a new text message: {concealedMessage}");
		}
	}
}