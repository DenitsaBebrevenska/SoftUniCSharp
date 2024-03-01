namespace CalculateTriangleArea
{
	internal class Program
	{
		static void Main()
		{
			double baseTriangle = double.Parse(Console.ReadLine());
			double height = double.Parse(Console.ReadLine());
			double area = CalculateTriangleArea(baseTriangle, height);
			Console.WriteLine(area);
		}

		static double CalculateTriangleArea(double baseTriangle, double height)
		{
			return baseTriangle * height / 2;
		}
	}
}