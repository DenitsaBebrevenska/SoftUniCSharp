namespace GeometryCalculator
{
	internal class Program
	{
		static void Main()
		{
			string figure = Console.ReadLine();
			double firstParameter = double.Parse(Console.ReadLine());
			double secondParameter = 0;
			if (figure == "triangle" || figure == "rectangle")
			{
				secondParameter = double.Parse(Console.ReadLine());
			}

			double area = 0;

			switch (figure)
			{
				case "triangle":
					area = CalculateTriangleArea(firstParameter, secondParameter);
					break;
				case "square":
					area = CalculateSquareArea(firstParameter);
					break;
				case "rectangle":
					area = CalculateRectangleArea(firstParameter, secondParameter);
					break;
				case "circle":
					area = CalculateCircleArea(firstParameter);
					break;
			}

			Console.WriteLine($"{area:F2}");
		}

		static double CalculateTriangleArea(double baseTriangle, double height)
		{
			return 0.5 * baseTriangle * height;
		}

		static double CalculateSquareArea(double side)
		{
			return side * side;
		}

		static double CalculateRectangleArea(double width, double length)
		{
			return length * width;
		}

		static double CalculateCircleArea(double radius)
		{
			return Math.PI * Math.Pow(radius, 2);
		}
	}
}
