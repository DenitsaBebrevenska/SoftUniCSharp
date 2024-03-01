namespace SimpleTextEditor
{
	internal class Program
	{
		static void Main()
		{
			int numberOfCommands = int.Parse(Console.ReadLine());
			string text = string.Empty;
			Stack<string> textHistory = new Stack<string>();

			for (int i = 0; i < numberOfCommands; i++)
			{
				
				string[] commandArgs = Console.ReadLine().Split();

				switch (commandArgs[0])
				{
					case "1":
						textHistory.Push(text);
						string textToAppend = commandArgs[1];
						text += textToAppend;
						break;
					case "2":
						textHistory.Push(text);
						int eraseCount = int.Parse(commandArgs[1]);
						text = text.Remove(text.Length - eraseCount, eraseCount);
						break;
					case "3":
						int index = int.Parse(commandArgs[1]) - 1;
						Console.WriteLine(text[index]);
						break;
					case "4":
						text = textHistory.Pop();
						break;
				}
			}
		}
	}
}
