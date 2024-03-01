namespace ArrayManipulator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] initialArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			string manipulation;
			while ((manipulation = Console.ReadLine()) != "end")
			{
				string[] command = manipulation.Split(" ");
				if (manipulation.Contains("exchange"))
				{
					int index = int.Parse(command[1]);
					if (index >= 0 && index <= initialArray.Length - 1)
					{
						initialArray = ExchangePositions(index, initialArray);
					}
					else
					{
						Console.WriteLine("Invalid index");
						continue;
					}
				}
				else if (manipulation.Contains("max"))
				{
					string evenOrOdd = command[1];
					if (evenOrOdd == "even")
					{
						int maxIndex = GetMaxEven(initialArray);
						if (maxIndex >= 0)
						{
							Console.WriteLine(maxIndex);
						}
						else
						{
							Console.WriteLine("No matches");
						}
					}
					else if (evenOrOdd == "odd")
					{
						int maxIndex = GetMaxOdd(initialArray);
						if (maxIndex >= 0)
						{
							Console.WriteLine(maxIndex);
						}
						else
						{
							Console.WriteLine("No matches");
						}
					}
				}
				else if (manipulation.Contains("min"))
				{
					string evenOrOdd = command[1];
					if (evenOrOdd == "even")
					{
						int minIndex = GetMinEven(initialArray);
						if (minIndex >= 0)
						{
							Console.WriteLine(minIndex);
						}
						else
						{
							Console.WriteLine("No matches");
						}
					}
					else if (evenOrOdd == "odd")
					{
						int minIndex = GetMinOdd(initialArray);
						if (minIndex >= 0)
						{
							Console.WriteLine(minIndex);
						}
						else
						{
							Console.WriteLine("No matches");
						}
					}
				}
				else if (manipulation.Contains("first"))
				{
					int count = int.Parse(command[1]);
					string evenOrOdd = command[2];
					if (count > initialArray.Length || count < 0) //adding a check if the input is a negative number
					{
						Console.WriteLine("Invalid count");
						continue;
					}
					if (evenOrOdd == "even")
					{
						string printMessage = GetFirstEven(initialArray, count);
						Console.WriteLine($"[{printMessage}]");
					}
					else if (evenOrOdd == "odd")
					{
						string printMessage = GetFirstOdd(initialArray, count);
						Console.WriteLine($"[{printMessage}]");
					}
				}
				else if (manipulation.Contains("last"))
				{
					int count = int.Parse(command[1]);
					string evenOrOdd = command[2];
					if (count > initialArray.Length || count < 0) //adding check if the input is a negative number
					{
						Console.WriteLine("Invalid count");
						continue;
					}
					if (evenOrOdd == "even")
					{
						string printMessage = GetLastEven(initialArray, count);
						Console.WriteLine($"[{printMessage}]");
					}
					else if (evenOrOdd == "odd")
					{
						string printMessage = GetLastOdd(initialArray, count);
						Console.WriteLine($"[{printMessage}]");
					}
				}
			}

			string printFinalArray = string.Join(", ", initialArray);
			Console.WriteLine($"[{printFinalArray}]");
		}
		static int[] ExchangePositions(int index, int[] initialArray)
		{
			int[] firstArray = new int[index + 1];
			int[] secondArray = new int[initialArray.Length - (index + 1)];
			for (int i = 0; i <= index; i++)
			{
				firstArray[i] = initialArray[i];
			}

			int j = 0;
			for (int i = index + 1; i <= initialArray.Length - 1; i++)
			{
				secondArray[j] = initialArray[i];
				j++;
			}

			int[] newArray = secondArray.Concat(firstArray).ToArray();
			return newArray;
		}

		static int GetMaxEven(int[] initialArray)
		{
			int maxEvenIndex = -1;
			int maxInt = int.MinValue;
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] % 2 == 0 && initialArray[i] >= maxInt)
				{
						maxInt = initialArray[i];
						maxEvenIndex = i;
				}
			}
				return maxEvenIndex;
		}
		static int GetMaxOdd(int[] initialArray)
		{
			int maxOddIndex = -1;
			int maxInt = int.MinValue;
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] % 2 != 0 && initialArray[i] >= maxInt)
				{
						maxInt = initialArray[i];
						maxOddIndex = i;
				}
			}	
				return maxOddIndex;
		}
		static int GetMinEven(int[] initialArray)
		{
			int minEvenIndex = -1;
			int minInt = int.MaxValue;
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] <= minInt && initialArray[i] % 2 == 0)
				{
					minInt = initialArray[i];
					minEvenIndex = i;
				}
			}

			return minEvenIndex;
		}
		static int GetMinOdd(int[] initialArray)
		{
			int minOddIndex = -1;
			int minInt = int.MaxValue;
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] % 2 != 0 && initialArray[i] <= minInt)
				{
						minInt = initialArray[i];
						minOddIndex = i;
				}
			}

			return minOddIndex;
		}

		static string GetFirstEven(int[] initialArray, int count)
		{
			string numbers = string.Empty;
			if (count == 0)
			{ return string.Empty; }
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] % 2 == 0)
				{
					numbers += initialArray[i] + ", ";
					count--;
					if (count == 0)
					{
						break;
					}
				}
			}

			numbers = numbers.TrimEnd(',', ' ');
			return numbers;
		}
		static string GetFirstOdd(int[] initialArray, int count)
		{
			string numbers = string.Empty;
			if (count == 0)
			{ return string.Empty; }
			for (int i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] % 2 != 0)
				{
					numbers += initialArray[i] + ", ";
					count--;
					if (count == 0)
					{
						break;
					}
				}
			}
			numbers = numbers.TrimEnd(',', ' ');
			return numbers;
		}

		static string GetLastEven(int[] initialArray, int count)
		{
			string numbers = string.Empty;
			if (count == 0)
			{ return string.Empty; }
			for (int i = initialArray.Length - 1; i >= 0; i--)
			{
				if (initialArray[i] % 2 == 0)
				{
					numbers = initialArray[i] + ", " + numbers;
					count--;
					if (count == 0)
					{
						break;
					}
				}
			}
			numbers = numbers.TrimEnd(',', ' ');
			return numbers;
		}
		static string GetLastOdd(int[] initialArray, int count)
		{
			string numbers = string.Empty;
			if (count == 0)
			{ return string.Empty; }

			for (int i = initialArray.Length - 1; i >= 0; i--)
			{
				if (initialArray[i] % 2 != 0)
				{
					numbers = initialArray[i] + ", " + numbers;
					count--;
					if (count == 0)
					{
						break;
					}
				}
			}
			numbers = numbers.TrimEnd(',', ' ');
			return numbers;
		}
	}
}