namespace WaterOverflow
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); // number of times an input will follow with liters of water
			int capacity = 255;
			int filled = 0;
			for (int i = 1; i <= n; i++)
			{
				int liters = int.Parse(Console.ReadLine());
				if (capacity < liters)
				{
					Console.WriteLine("Insufficient capacity!");
				}
				else
				{
					capacity -= liters;
					filled += liters;
				}
			}
            Console.WriteLine(filled);

        }
	}
}