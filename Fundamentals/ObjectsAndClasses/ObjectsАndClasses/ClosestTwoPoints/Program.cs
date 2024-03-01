namespace ClosestTwoPoints
{
	internal class Program
	{
		static void Main()
		{
			byte numberOfPoints = byte.Parse(Console.ReadLine());
			Point[] points = new Point[numberOfPoints];

			for (byte i = 0; i < numberOfPoints; i++)
			{
				int[] pointCoordinates = Console.ReadLine().
					Split().
					Select(int.Parse).
					ToArray();
					points[i] = new Point(pointCoordinates[0], pointCoordinates[1]);
			}

			Console.WriteLine($"{GetClosestPointsDetails(points)}");
		}

		static string GetClosestPointsDetails(Point[] points)
		{
			double minDistance = double.MaxValue;
			string closestPoints = string.Empty;

			for (int i = 0; i < points.Length - 1; i++)
			{
				for (int j = i + 1; j < points.Length; j++)
				{
					double currentDistance = CalculateDistance(points[i], points[j]);

					if (currentDistance < minDistance)
					{
						minDistance = currentDistance;
						closestPoints = $"({points[i].X}, {points[i].Y})\n({points[j].X}, {points[j].Y})";
					}
				}
			}

			Console.WriteLine($"{minDistance:F3}");
			return closestPoints;
		}
		static double CalculateDistance(Point point1, Point point2)
		{
			return Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
		}
	}
}
