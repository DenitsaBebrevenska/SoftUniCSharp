namespace ArrayManipulatorTake2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

			string input;
			while ((input = Console.ReadLine()) != "end") 
			{
				string[] arguments = input.Split();

				switch (arguments[0])
				{
					case "exchange":
						int index = int.Parse(arguments[1]);
						numbers = Exchange(index, numbers);
						break;
					case "max":
						string maxEvenOrOdd = arguments[1];
						FindMaxNumber(maxEvenOrOdd, numbers);
						break;
					case "min":
							string minEvenOrOdd = arguments[1];
							FindMinNumber(minEvenOrOdd, numbers);
							break;
					case "first":
						int firstCount = int.Parse(arguments[1]);
						string firstEvenOrOdd = arguments[2];
						PrintFirstElements(firstCount, firstEvenOrOdd, numbers);
						break;
					case "last":
						int lastCount = int.Parse(arguments[1]);
						string lastEvenOrOdd = arguments[2];
						PrintLastElements(lastCount, lastEvenOrOdd, numbers);
						break;
				}
			}
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
		static bool CheckForOutOfBound(int index, int[] numbers)
		{
			return index < 0 || index >= numbers.Length;
			
		}
		static bool CheckIndex(int index, int[] numbers)
		{
			return index > numbers.Length;
		}
		static void PrintIndex(int index)
		{
			if (index != -1)
			{
				Console.WriteLine(index);
			}
			else
			{
				Console.WriteLine("No matches");
			}
		}
		static bool IsOddOrEven(string evenOrOdd, int number)
		{
			return (evenOrOdd == "odd" && number % 2 != 0) || (evenOrOdd == "even" && number % 2 == 0);
		}
		
		static int[] Exchange(int index, int[] numbers)
		{
			if (CheckForOutOfBound(index, numbers))
			{
                Console.WriteLine("Invalid index");
				return numbers;
            }
			int[] newArray = new int[numbers.Length];
			int j = 0;
			for (int i = index + 1; i < numbers.Length; i++)
			{
				newArray[j] = numbers[i];
				j++;
			}
			for (int i = 0; i <= index; i++)
			{
				newArray[j] = numbers[i];
				j++;
			}
			return newArray;
		}
		static void FindMaxNumber(string maxEvenOrOdd, int[] numbers)
		{
			int maxIndex = -1;
			int maxNumber = int.MinValue;
			for (int i = 0; i < numbers.Length; i++)
			{
				if (IsOddOrEven(maxEvenOrOdd, numbers[i]))
				{
					if (numbers[i] >= maxNumber)
					{
						maxNumber = numbers[i];
						maxIndex = i;
					}
				}
			}
			PrintIndex(maxIndex);
        }
		static void FindMinNumber(string minEvenOrOdd, int[] numbers)
		{
			int minIndex = -1;
			int minNumber = int.MaxValue;
			for (int i = 0; i < numbers.Length; i++)
			{
				if (IsOddOrEven(minEvenOrOdd, numbers[i]))
				{
					if (numbers[i] <= minNumber)
					{
						minNumber = numbers[i];
						minIndex = i;
					}
				}
			}
			PrintIndex(minIndex);
		}
		static void PrintFirstElements(int firstCount, string firstEvenOrOdd, int[] numbers)
		{
			if (CheckIndex(firstCount, numbers))
			{
                Console.WriteLine("Invalid count");
				return;
            }
			string firstElements = "";
			int elementCount = 0;
			for (int i = 0; i < numbers.Length; i++)
			{
				if (IsOddOrEven(firstEvenOrOdd, numbers[i]))
				{
					firstElements += $"{numbers[i]}, ";
					elementCount++;
					if (elementCount == firstCount)
					{
						break;
					}
				}
			}
            Console.WriteLine($"[{firstElements.Trim(' ', ',')}]");
        }
		static void PrintLastElements(int lastCount, string lastEvenOrOdd, int[] numbers)
		{
			if (CheckIndex(lastCount, numbers))
			{
				Console.WriteLine("Invalid count");
				return;
			}
			string lastElements = "";
			int elementCount = 0;
			for (int i = numbers.Length - 1; i >= 0; i--)
			{
				if (IsOddOrEven(lastEvenOrOdd, numbers[i]))
				{
					lastElements = $"{numbers[i]}, " + lastElements;
					elementCount++;
					if (elementCount == lastCount)
					{
						break;
					}
				}
			}
			Console.WriteLine($"[{lastElements.Trim(' ', ',')}]");
		}
	}
}