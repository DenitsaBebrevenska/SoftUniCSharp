namespace StackSum
{
	internal class Program
	{
		static void Main()
		{
			Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
			string input;

			while ((input = Console.ReadLine()).ToLower() != "end")
			{
				string[] commandArgs = input.ToLower().Split();
				string command = commandArgs[0];

				switch (command)
				{
					case "add":
						int number1 = int.Parse(commandArgs[1]);
						int number2 = int.Parse(commandArgs[2]);
						numbers.Push(number1);
						numbers.Push(number2);
						break;
					case "remove":
						int countRemove = int.Parse(commandArgs[1]);

						if (numbers.Count < countRemove)
						{
							continue;
						}

						for (int i = 0; i < countRemove; i++)
						{
							numbers.Pop();
						}
						break;
				}
			}

			Console.WriteLine($"Sum: {numbers.Sum()}");
		}
	}
}
