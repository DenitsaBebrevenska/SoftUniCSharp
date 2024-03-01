namespace _LongerLine
{
	internal class Program
	{
		static void Main()
		{   //the input is total of 8 lines, 4 lines per line,  2 for each point from the line
			double[] line1Coordinates = GetCoordinates();
			double[] line2Coordinates = GetCoordinates();
			double[] longerLine = CompareDistances(line1Coordinates, line2Coordinates);
			PrintLongerLine(longerLine);
		}
		static double[] GetCoordinates()
		{
			double[] coordinates = new double[4];
			for (int i = 0; i < coordinates.Length; i++)
			{
				coordinates[i] = double.Parse(Console.ReadLine());
			}
			return coordinates;
		}
		static double CalculateDistance(double[] lineCoordinates)
		{
			//√((X2 - X1)² + (Y2 - Y1)²) - calculate the length/distance of a line
			double x1 = lineCoordinates[0];
			double y1 = lineCoordinates[1];
			double x2 = lineCoordinates[2];
			double y2 = lineCoordinates[3];
			return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
		}
		static double[] CompareDistances(double[] line1Coordinates, double[] line2Coordinates)
		{
			double distance1 = CalculateDistance(line1Coordinates);
			double distance2 = CalculateDistance(line2Coordinates);
			if (distance1 >= distance2)
			{
				return line1Coordinates;
			}
			else 
			{
				return line2Coordinates;
			}
		}
		static void PrintLongerLine(double[] coordinates)
		{
			// √((X2 - X1)² + (Y2 - Y1)²) where x1,y1 is the center will calculate each point length from 0, 0
			double[] coordinatesPointA = new double[2] { coordinates[0], coordinates[1] };
			double[] coordinatesPointB = new double[2] { coordinates[2], coordinates[3] };
			double distanceA = Math.Sqrt(Math.Pow((coordinatesPointA[0] - 0), 2) + Math.Pow((coordinatesPointA[1] - 0), 2));
			double distanceB = Math.Sqrt(Math.Pow((coordinatesPointB[0] - 0), 2) + Math.Pow((coordinatesPointB[1] - 0), 2));
			if (distanceA <= distanceB)
			{
                Console.WriteLine($"({coordinates[0]}, {coordinates[1]})({coordinates[2]}, {coordinates[3]})");
            }
			else
			{
				Console.WriteLine($"({coordinates[2]}, {coordinates[3]})({coordinates[0]}, {coordinates[1]})");
			}
		}
	}
}