namespace CenterPoints
{
	internal class Program
	{
		static void Main() // actually using the distance formula not making new maths!
		{
			double x1 = double.Parse(Console.ReadLine());
			double y1 = double.Parse(Console.ReadLine());
			double x2 = double.Parse(Console.ReadLine());
		    double y2 = double.Parse(Console.ReadLine());
			
			ComparePoints(x1, y1, x2, y2);
		}
		static double CalculateDistanceToCenter(double x, double y)
		{
			// √((X2 - X1)² + (Y2 - Y1)²)
			return Math.Sqrt(Math.Pow((x - 0), 2) + Math.Pow((y - 0), 2));
		}
		static void ComparePoints(double x1, double y1, double x2, double y2)
		{
			double distance1 = CalculateDistanceToCenter(x1, y1);
			double distance2 = CalculateDistanceToCenter(x2, y2);
			if (distance1 <= distance2)
			{
				Console.WriteLine($"({x1}, {y1})");
			}
			else
			{
				Console.WriteLine($"({x2}, {y2})");
			}
		}
	}
}