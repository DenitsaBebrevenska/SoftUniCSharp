namespace MemoryGame
{
	internal class Program
	{
		static void Main()
		{
			List<string> elements = Console.ReadLine().
				Split().
				ToList();
			string input;
			int movesCount = 0;
			while ((input = Console.ReadLine()) != "end")
			{
				int[] playersChoice = input.Split(' ').
					Select(int.Parse).
					ToArray();
				int firstIndex = playersChoice[0];
				int secondIndex = playersChoice[1];
				movesCount++;
				if (ValidIndeces(firstIndex,secondIndex, elements.Count))
				{
					if (elements[firstIndex] == elements[secondIndex])
					{
						Console.WriteLine($"Congrats! You have found matching elements - {elements[firstIndex]}!");
						string elementToRemove = elements[firstIndex];
						elements.Remove(elementToRemove);
						elements.Remove(elementToRemove);
					}
					else
					{
						Console.WriteLine("Try again!");
						continue;
					}
				}
				else
				{ 
					elements = AddElements(elements, movesCount);
					Console.WriteLine("Invalid input! Adding additional elements to the board");
				}

				if (GameWon(elements.Count))
				{
					Console.WriteLine($"You have won in {movesCount} turns!");
					return;
				}
			}

			Console.WriteLine("Sorry you lose :(");
			Console.WriteLine(string.Join(' ',elements));
		}

		static bool ValidIndeces(int firstIndex, int secondIndex, int listCount)
		{
			return firstIndex != secondIndex && 
			       (firstIndex < listCount && firstIndex >= 0 &&
			        secondIndex < listCount && secondIndex >= 0);
		}

		static List<string> AddElements(List<string> elements, int movesCount)
		{ 
			string addition = $"-{movesCount}a";
			int index = elements.Count / 2;
			elements.Insert(index, addition);
			elements.Insert(index, addition);
			return elements;
		}

		static bool GameWon(int elementsCount)
		{
			return elementsCount == 0;
		}
	}
} 