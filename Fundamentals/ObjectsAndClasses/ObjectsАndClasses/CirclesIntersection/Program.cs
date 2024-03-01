namespace CirclesIntersection
{
	internal class Program
	{
		static void Main()
		{
			int[] circle1Args = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToArray();
			int[] circle2Args = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToArray();
			Circle c1 = new Circle(new Point(circle1Args[0], circle1Args[1]), circle1Args[2]);
			Circle c2 = new Circle(new Point(circle2Args[0], circle2Args[1]), circle2Args[2]);

			Console.WriteLine(Intersect(c1, c2) ? "Yes" : "No");
		}

		static bool Intersect(Circle c1, Circle c2)
		{
			double distanceBetweenCenters = CalculateDistance(c1.Center, c2.Center);
			return distanceBetweenCenters <= c1.Radius + c2.Radius;
		}
		static double CalculateDistance(Point point1, Point point2)
		{
			return Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
		}
	}
	
}
