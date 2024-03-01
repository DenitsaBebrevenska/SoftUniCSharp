using System;

namespace RageExpenses
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int loss = int.Parse(Console.ReadLine());
			double headsetPrice = double.Parse(Console.ReadLine());
			double mousePrice = double.Parse(Console.ReadLine());
			double keyboardPrice = double.Parse(Console.ReadLine());
			double displayPrice = double.Parse(Console.ReadLine());

			int trashedHeadsets = 0, trashedMice = 0, trashedKeyboards = 0, trashedDisplays = 0;

			if (loss / 12 > 0)
			{
				trashedDisplays = loss / 12;
			}
			if (loss / 6 > 0)
			{
				trashedKeyboards = loss / 6;
			}
			if (loss / 3 > 0)
			{
				trashedMice = loss / 3;
			}
			if (loss / 2 > 0)
			{
				trashedHeadsets = loss / 2;
			}

			double sum = displayPrice * trashedDisplays + keyboardPrice * trashedKeyboards + mousePrice * trashedMice
				+ headsetPrice * trashedHeadsets;
            Console.WriteLine($"Rage expenses: {sum:F2} lv.");

		}
	}
}