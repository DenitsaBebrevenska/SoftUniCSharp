namespace KaminoFactory
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int sequenceLenght = int.Parse(Console.ReadLine());
			string input = Console.ReadLine();
			
			int bestLineSum = 0;
			int bestIndexOfAll = 0;
			int lineCounter = 0;
			int bestLineNumber = 0;
			int longestSequenceOfAll = -1; //-1 in case the input has no 1s at all...
			int[] bestSequence = new int[sequenceLenght];

			while (input != "Clone them!")
			{
				int[] currentLine = input.Split('!', StringSplitOptions.RemoveEmptyEntries)
					                      .Select(int.Parse)
					                      .ToArray();
				lineCounter++;
				int currentLineSum = currentLine.Sum();
				int currentSequence = 0;
				int longestSequenceThisLine = 0;
				int bestLineIndex = 0;
				int currentLineBestIndex = 0;
				for (int i = 0; i < currentLine.Length; i++)
				{
					if (currentLine[i] == 1)
					{
						if (currentSequence == 0)
						{
							currentLineBestIndex = i;
						}
						currentSequence++;
					}
					else
					{
						currentSequence = 0;
					}

					if (currentSequence > longestSequenceThisLine)
					{
						longestSequenceThisLine = currentSequence;
						bestLineIndex = currentLineBestIndex;
					}
				}
				if (longestSequenceThisLine > longestSequenceOfAll ||
						(longestSequenceThisLine == longestSequenceOfAll && bestLineIndex < bestIndexOfAll) ||
						(longestSequenceThisLine == longestSequenceOfAll && bestLineIndex == bestIndexOfAll
						&& currentLineSum > bestLineSum))
				{
					longestSequenceOfAll = longestSequenceThisLine;
					bestIndexOfAll = bestLineIndex;
					bestLineSum = currentLineSum;
					bestSequence = currentLine;
					bestLineNumber = lineCounter;
				}

				input = Console.ReadLine();
			}
			string output = string.Join(" ", bestSequence);
			Console.WriteLine($"Best DNA sample {bestLineNumber} with sum: {bestLineSum}.");
			Console.WriteLine(output);
		}
	}
}