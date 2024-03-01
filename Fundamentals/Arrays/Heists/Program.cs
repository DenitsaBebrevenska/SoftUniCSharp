namespace Heists
{
	internal class Program
	{
		static void Main()
		{
			int[] price = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToArray();
			int priceJewels = price[0];
			int priceGold = price[1];

			int totalExpenses = 0;
			int totalGain = 0;

			string action;
			while ((action = Console.ReadLine()) != "Jail Time")
			{
				//“{loot} {heist expenses}” 
				string[] actionArgs = action.Split();
				string loot = actionArgs[0];
				int expenses = int.Parse(actionArgs[1]);

				int jewelCount = loot.Count(x => x == '%');
				int goldCount = loot.Count(x => x == '$');

				totalGain += jewelCount * priceJewels + goldCount * priceGold;
				totalExpenses += expenses;
			}

			Console.WriteLine(totalGain >= totalExpenses ? $"Heists will continue. Total earnings: {totalGain - totalExpenses}." :
				$"Have to find another job. Lost: {totalExpenses - totalGain}.");
		}
	}
}
