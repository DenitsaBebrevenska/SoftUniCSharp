namespace MilesToKilometers
{
	internal class Program
	{
		static void Main()
		{
			double miles = double.Parse(Console.ReadLine());

			double kilometers = miles * 1.60934;
			Console.WriteLine($"{kilometers:F2}");
		}
	}
}