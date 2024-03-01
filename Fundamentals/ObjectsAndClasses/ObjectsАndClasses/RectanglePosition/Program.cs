namespace RectanglePosition
{
	internal class Program
	{
		static void Main()
		{
				int[] r1Args = Console.ReadLine().
					Split().Select(int.Parse).
					ToArray(); // r = rectangle
				int[] r2Args = Console.ReadLine().
					Split().
					Select(int.Parse).
					ToArray(); // r = rectangle
				Rectangle rectangle1 = 
					new Rectangle((new Point(r1Args[0], r1Args[1])), r1Args[2], r1Args[3]);
				Rectangle rectangle2 = 
					new Rectangle((new Point(r2Args[0], r2Args[1])), r2Args[2], r2Args[3]);

				Console.WriteLine(IsInside(rectangle1, rectangle2) ? "Inside" : "Not inside");
		}

		static bool IsInside(Rectangle r1, Rectangle r2)
		{
			return 
				   r1.TopLeftCorner.X >= r2.TopLeftCorner.X
				&& r1.TopLeftCorner.Y >= r2.TopLeftCorner.Y
				&& r1.BottomRightCorner.X <= r2.BottomRightCorner.X
				&& r1.BottomRightCorner.Y <= r2.BottomRightCorner.Y;
		}
	}
}
