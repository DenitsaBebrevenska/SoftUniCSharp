using System;

namespace CubeProperties
{
	internal class Program
	{
		static void Main()
		{
			double side = double.Parse(Console.ReadLine());
			string parameter = Console.ReadLine();
			double result = 0;

			switch (parameter)
			{
				case "face":
					result = CalculateCubeFace(side);
					break;
				case "space":
					result = CalculateCubeSpace(side);
					break;
				case "volume":
					result = CalculateCubeVolume(side);
					break;
				case "area":
					result = CalculateCubeArea(side);
					break;
			}
			Console.WriteLine($"{result:F2}");
		}
		static double CalculateCubeFace(double side)
		{
			return Math.Sqrt(2 * Math.Pow(side, 2));
		}

		static double CalculateCubeSpace(double side)
		{
			return Math.Sqrt(3 * Math.Pow(side, 2));
		}

		static double CalculateCubeVolume(double side)
		{
			return Math.Pow(side, 3);
		}

		static double CalculateCubeArea(double side)
		{
			return 6 * Math.Pow(side, 2);
		}
	}
}
