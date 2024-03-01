namespace CenterPoint
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double x1 = double.Parse(Console.ReadLine());
			double y1 = double.Parse(Console.ReadLine());
			double x2 = double.Parse(Console.ReadLine());
			double y2 = double.Parse(Console.ReadLine());

			ComputeAndPrint(x1, y1, x2, y2);
		}

		static void ComputeAndPrint(double x1, double y1, double x2, double y2)
		{
			double difference1 = Math.Abs(x1) + Math.Abs(y1);
			double difference2 = Math.Abs(x2) + Math.Abs(y2);
			
			string closestPoint = CompareDifference(difference1, difference2);
			string result = (closestPoint == "difference2") ? $"({x2}, {y2})" : $"({x1}, {y1})";
			Console.WriteLine(result);
		}

		static string CompareDifference(double difference1, double difference2)
		{
			if (difference2 < difference1)
			{
				return "difference2";
			}
			else
			{
				return "difference1";
			}
		}
	}
}