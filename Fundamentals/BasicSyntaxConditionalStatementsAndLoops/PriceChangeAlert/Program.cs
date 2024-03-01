using System;
class PriceChangeAlert
{

	//Code to refactor
	/*
	static void Main()
	{
		 int n = int.Parse(Console.ReadLine());



		double threshold = double.Parse(Console.ReadLine());


		double lastPrice = double.Parse(Console.ReadLine());

		for (int i = 0; i < n - 1; i++)
		{
			double currentPrice = double.Parse(Console.ReadLine());
			double div = CalculatePercentageChange(lastPrice, currentPrice); bool isSignificantDifference = ChangeIsAboveThreshold(div, threshold);



			string message = GenerateOutput(currentPrice, lastPrice, div, isSignificantDifference);
			Console.WriteLine(message);

			lastPrice = currentPrice;
		}
	}

	private static string GenerateOutput(double currentPrice, double lastPrice, double change, bool isSignificantDifference)






	{
		string to = "";
		if (change == 0)
		{
			to = string.Format("NO CHANGE: {0}", currentPrice);
		}
		else if (!isSignificantDifference)
		{
			to = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, change);
		}
		else if (isSignificantDifference && (change > 0))
		{
			to = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, change);
		}
		else if (isSignificantDifference && (change < 0))
			to = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, change);
		return to;
	}
	private static bool ChangeIsAboveThreshold(double threshold, double change)
	{
		if (Math.Abs(threshold) >= change)
		{
			return true;
		}
		return false;
	}

	private static double CalculatePercentageChange(double lastPrice, double currentPrice)
	{
		double r = (currentPrice - lastPrice) / lastPrice;
		return r;
	}
	*/
	static void Main()
	{
		int numberOfPrices = int.Parse(Console.ReadLine());
		double threshold = double.Parse(Console.ReadLine());
		double lastPrice = double.Parse(Console.ReadLine());

		for (int i = 0; i < numberOfPrices - 1; i++)
		{
			double currentPrice = double.Parse(Console.ReadLine());
			double change = CalculatePercentageChange(lastPrice, currentPrice);
			bool isSignificantDifference = ChangeIsAboveThreshold(threshold, change);
			string output = GenerateOutput(currentPrice, lastPrice, change, isSignificantDifference);
			Console.WriteLine(output);

			lastPrice = currentPrice;
		}
	}

	private static string GenerateOutput(double currentPrice, double lastPrice, double change, bool isSignificantDifference)
	{
		string to = "";
		if (change == 0)
		{
			to = string.Format("NO CHANGE: {0}", currentPrice);
		}
		else if (!isSignificantDifference)
		{
			to = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, change * 100);
		}
		else if (isSignificantDifference && (change > 0))
		{
			to = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, change * 100);
		}
		else if (isSignificantDifference && (change < 0))
		{
			to = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, change * 100);
		}

		return to;
	}
	private static bool ChangeIsAboveThreshold(double threshold, double change)
	{
		if (Math.Abs(threshold) <= Math.Abs(change))
		{
			return true;
		}
		return false;
	}

	private static double CalculatePercentageChange(double lastPrice, double currentPrice)
	{
		double percentageChange = (currentPrice - lastPrice) / lastPrice;
		return percentageChange;
	}
}