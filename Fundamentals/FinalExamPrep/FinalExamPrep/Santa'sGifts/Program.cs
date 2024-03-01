namespace Santa_sGifts
{
	internal class Program
	{
		static void Main()
		{
			int commandCount = int.Parse(Console.ReadLine());
			List<string> houseNumbers = Console.ReadLine().
				Split().
				ToList();

			int currentPosition = 0;

			for (int i = 0; i < commandCount; i++)
			{
				string[] commandArgs = Console.ReadLine().Split();
				string action = commandArgs[0];
				int value = int.Parse(commandArgs[1]);

				if (action == "Forward" && currentPosition + value < houseNumbers.Count)
				{
					currentPosition += value;
					houseNumbers.RemoveAt(currentPosition);

				}
				else if (action == "Back" && currentPosition - value >= 0)
				{
					currentPosition -= value;
					houseNumbers.RemoveAt(currentPosition);
				}
				else if (action == "Gift" && value >= 0 && value < houseNumbers.Count)
				{
					string houseNumber = commandArgs[2];
					houseNumbers.Insert(value, houseNumber);
					currentPosition = value;

				}
				else if (action == "Swap")
				{
					string value2 = commandArgs[2];
					int indexValue1 = houseNumbers.IndexOf(value.ToString());
					int indexValue2 = houseNumbers.IndexOf(value2);

					if (indexValue1 == -1 || indexValue2 == - 1) //case one or both items do not exist in the array
					{
						continue;
					}
					houseNumbers[indexValue1] = value2;
					houseNumbers[indexValue2] = value.ToString();
				}
			}

			Console.WriteLine($"Position: {currentPosition}");
			Console.WriteLine(string.Join(", ", houseNumbers));
		}
	}
}
