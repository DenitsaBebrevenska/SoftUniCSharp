namespace BeverageLabels
{
	internal class Program
	{
		static void Main()
		{
			string productName = Console.ReadLine();
			int volumeInMl = int.Parse(Console.ReadLine());
			int energyPer100Ml = int.Parse(Console.ReadLine());
			int sugarPer100Ml = int.Parse(Console.ReadLine());

			double totalEnergy = volumeInMl / 100.00 * energyPer100Ml;
			double totalSugar = volumeInMl / 100.00 * sugarPer100Ml;
			Console.WriteLine($"{volumeInMl}ml {productName}:");
			Console.WriteLine($"{totalEnergy:F2}kcal, {totalSugar:F2}g sugars");

		}
	}
}