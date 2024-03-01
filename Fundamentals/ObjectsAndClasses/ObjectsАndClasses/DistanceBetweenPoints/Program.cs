namespace DistanceBetweenPoints
{
	internal class Program
	{
		static void Main()
		{
			int[] point1Coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int[] point2Coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

			Point point1 = new Point(point1Coordinates[0], point1Coordinates[1]);
			Point point2 = new Point(point2Coordinates[0], point2Coordinates[1]);

			Console.WriteLine($"{CalculateDistance(point1, point2):F3}");
		}

		static double CalculateDistance(Point point1, Point point2)
		{
			return Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
		}
	}

}
