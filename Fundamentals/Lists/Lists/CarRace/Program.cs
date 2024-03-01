namespace CarRace
{
	internal class Program
	{
		static void Main()
		{
			int[] track = Console.ReadLine().
				Split(' ').
				Select(int.Parse).
				ToArray();
			int indexFinish = track.Length / 2;
			double leftTotalTime = CalculateLeftCarTime(track, indexFinish);
			double rightTotalTime = CalculateRightCarTime(track, indexFinish);

			PrintWinner(leftTotalTime, rightTotalTime);
		}

		private static void PrintWinner(double leftTotalTime, double rightTotalTime)
		{
			if (leftTotalTime > rightTotalTime)
			{
				Console.WriteLine($"The winner is right with total time: {FormatResult(rightTotalTime)}");
			}
			else
			{
				Console.WriteLine($"The winner is left with total time: {FormatResult(leftTotalTime)}");
			}
		}

		static double CalculateLeftCarTime(int[] track, int indexFinish)
		{
			double sum = 0;
			for (int i = 0; i < indexFinish; i++)
			{
				if (track[i] == 0)
				{
					sum *= 0.8;
				}
				else
				{
					sum += track[i];
				}
			}
			return sum;
		}
		static double CalculateRightCarTime(int[] track, int indexFinish)
		{
			double sum = 0;
			for (int i = track.Length - 1; i > indexFinish; i--)
			{
				if (track[i] == 0)
				{
					sum *= 0.8;
				}
				else
				{
					sum += track[i];
				}
			}
			return sum;
		}
		static string FormatResult(double winnerTime)
		{
			if (winnerTime == (int)winnerTime)
			{
				return ((int)winnerTime).ToString();
			}
			return winnerTime.ToString("0.0");
		}
	}
}