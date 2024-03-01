namespace Megapixels
{
	internal class Program
	{
		static void Main()
		{
			int width = int.Parse(Console.ReadLine());
			int height = int.Parse(Console.ReadLine());

			double megapixels = Math.Round((width * height / 1_000_000.00), 1);

			Console.WriteLine($"{width}x{height} => {megapixels}MP");
		}
	}
}