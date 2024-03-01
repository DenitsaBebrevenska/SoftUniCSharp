using System.Runtime.InteropServices;

namespace ListManipulationAdvanced
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();

			string command;
			bool changesMade = false;
			while ((command = Console.ReadLine()) != "end")
			{
				string[] arguments = command.Split();
				
				if (arguments[0] == "Add" || arguments[0] == "Remove" || arguments[0] == "RemoveAt" || arguments[0] == "Insert")
				{ 
					changesMade = true;
				}

				switch (arguments[0])
				{
					case "Add":
						int numberToAdd = int.Parse(arguments[1]);
						numbers.Add(numberToAdd);
						break;
					case "Remove":
						int numberToRemove = int.Parse(arguments[1]);
						numbers.Remove(numberToRemove);
						break;
					case "RemoveAt":
						int indexRemoveNumber = int.Parse(arguments[1]);
						numbers.RemoveAt(indexRemoveNumber);
						break;
					case "Insert":
						int numberToInsert = int.Parse(arguments[1]);
						int indexInsert = int.Parse(arguments[2]);
						numbers.Insert(indexInsert, numberToInsert);
						break;
					case "Contains":
						int numberToCheck = int.Parse(arguments[1]);
						CheckForNumber(numberToCheck, numbers);
						break;
					case "PrintEven":
						PrintNumbers(numbers, arguments[0]);
						break;
					case "PrintOdd":
						PrintNumbers(numbers, arguments[0]);
						break;
					case "GetSum":
						PrintSum(numbers);
						break;
					case "Filter":
						string condition = arguments[1];
						int numberToCompare = int.Parse(arguments[2]);
						PrintConditionedNumbers(numbers, condition, numberToCompare);
						break;
				}
			}
			if (changesMade)
			{
			Console.WriteLine(string.Join(' ', numbers));
			}
		}
		static void CheckForNumber(int number, List<int> numbers)
		{
			if (numbers.Contains(number))
			{
				Console.WriteLine("Yes");
			}
			else
			{
				Console.WriteLine("No such number");
			}
		}
		static void PrintNumbers(List<int> numbers, string evenOrOdd)
		{
			foreach (int number in numbers)
			{
				if ((number % 2 == 0 && evenOrOdd == "PrintEven") ||
						(number % 2 == 1 && evenOrOdd == "PrintOdd"))
				{
					Console.Write(number + " ");
				}
			}
			Console.WriteLine();
		}
		static void PrintSum(List<int> numbers)
		{
			int sum = 0;
			for (int i = 0; i < numbers.Count; i++)
			{
				sum += numbers[i];
			}
			Console.WriteLine(sum);
		}
		static void PrintConditionedNumbers(List<int> numbers, string condition, int numberToCompare)
		{

			foreach (int number in numbers)
			{
				if ((condition == "<" && number < numberToCompare) || 
					(condition == ">" && number > numberToCompare) ||
					(condition == ">=" && number >= numberToCompare) ||
					(condition == "<=" && number <= numberToCompare))
				{
                    Console.Write(number + " ");
                }
			}
            Console.WriteLine();
        }
	}
}