using System.Numerics;

namespace Snowballs
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); // n - number of snowballs
			int bestSnow = 0, bestTime = 0, bestQuality = 0;
			BigInteger bestValue = 0;
			for (int i = 1; i <= n; i++)
			{
				int snow = int.Parse(Console.ReadLine());
				int time = int.Parse(Console.ReadLine());
				int quality = int.Parse(Console.ReadLine());
				BigInteger value = BigInteger.Pow((snow / time), quality);

				if (value > bestValue)
				{
					bestValue = value;
					bestSnow = snow;
					bestTime = time;
					bestQuality = quality;
				}
			}
			Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");

		}
	}
}