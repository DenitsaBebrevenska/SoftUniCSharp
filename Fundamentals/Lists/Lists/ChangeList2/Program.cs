namespace ChangeList2
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();
			string input = Console.ReadLine();

			while (true)
			{
				if (input == "Odd" || input == "Even")
				{
					break;
				}

				string[] commandArgs = input.Split();
				string command = commandArgs[0];
				int element = int.Parse(commandArgs[1]);

				if (command == "Delete")
				{
					numbers.RemoveAll(n => n == element);
				}
				else //Insert
				{
					int index = int.Parse(commandArgs[2]);
					numbers.Insert(index, element);
				}

				input = Console.ReadLine();
			}

			List<int> evenNumbers = new List<int>();
			List<int> oddNumbers = new List<int>();

			foreach (int number in numbers)
			{
				if (number % 2 == 0)
				{
					evenNumbers.Add(number);
				}
				else
				{
					oddNumbers.Add(number);
				}
			}

			Console.WriteLine(input == "Even" ? string.Join(" ", evenNumbers) : string.Join(" ", oddNumbers));
		}
	}
}
