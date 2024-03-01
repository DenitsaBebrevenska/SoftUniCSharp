using System.Diagnostics.CodeAnalysis;

namespace Orders
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string order = Console.ReadLine();
			int quantity = int.Parse(Console.ReadLine());
			CalculatePrice(order, quantity);
		}
		static void CalculatePrice(string order, int quantity)
		{
			double sum = 0;
			if (order == "coffee")
			{
				sum = quantity * 1.5;
			}
			else if (order == "water")
			{
				sum = quantity * 1;
			}
			else if (order == "coke")
			{
				sum = quantity * 1.4;
			}
            else if (order == "snacks")
            {
				sum = quantity * 2;
            }
            Console.WriteLine($"{sum:f2}");
        }
	}
}