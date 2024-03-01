using System;
using System.Text.RegularExpressions;

namespace Mines
{
	internal class Program
	{
		static void Main()
		{
			string mineMap = Console.ReadLine();
			string minePattern = @"<.{2}>";
			MatchCollection minesMatches = Regex.Matches(mineMap, minePattern);

			foreach (Match mine in minesMatches)
			{
				int indexMine = mine.Index;
				string currentMine = mine.ToString();
				int minePower = Math.Abs(currentMine[1] - currentMine[2]);
				int startIndexDestruction = indexMine - minePower;
				
				if (startIndexDestruction < 0)
				{
					startIndexDestruction = 0;
				}

				int endIndexDestruction = indexMine + 3 + minePower;

				if (endIndexDestruction > mineMap.Length - 1)
				{
					endIndexDestruction = mineMap.Length - 1;
				}

				int lengthExplosion = endIndexDestruction - startIndexDestruction + 1;

				mineMap = mineMap.Remove(startIndexDestruction, lengthExplosion);
				mineMap = mineMap.Insert(startIndexDestruction, new string('_', lengthExplosion));

			}

			Console.WriteLine(mineMap);
		}
	}
}
