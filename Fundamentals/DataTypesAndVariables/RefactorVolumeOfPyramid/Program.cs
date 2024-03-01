namespace RefactorVolumeOfPyramid
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Length: ");
			double lenght = double.Parse(Console.ReadLine());
			Console.Write("Width: ");
			double width = double.Parse(Console.ReadLine());
			Console.Write("Height: ");
			double height = double.Parse(Console.ReadLine());
			double volume = (1.0 / 3.0) * (lenght * width) * height;
			Console.Write($"Pyramid Volume: {volume:f2}");

		}
	}
}