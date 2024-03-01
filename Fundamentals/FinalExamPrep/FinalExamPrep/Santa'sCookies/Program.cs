namespace Santa_sCookies
{
	internal class Program
	{
		static void Main()
		{
			uint batchCount = uint.Parse(Console.ReadLine());
			int cookieGrams = 25, cupGrams = 140, smallSpoonGrams = 10, bigSpoonGrams = 20, cookiesPerBox = 5, totalBoxes = 0;

			for (int i = 0; i < batchCount; i++)
			{
				int flourGrams = int.Parse(Console.ReadLine());
				int sugarGrams = int.Parse(Console.ReadLine());
				int cocoaGrams = int.Parse(Console.ReadLine());

				int flourCups = flourGrams / cupGrams;
				int sugarSpoons = sugarGrams / bigSpoonGrams;
				int cocoaSpoons = cocoaGrams / smallSpoonGrams;

				if (flourCups <= 0 || sugarSpoons <= 0 || cocoaSpoons <= 0)
				{
					Console.WriteLine("Ingredients are not enough for a box of cookies.");
					continue;
				}

				//({cup} + {smallSpoon} + {bigSpoon}) * min from({flourCups}, {sugarSpoons}, {cocoaSpoons}) / singleCookieGrams
				decimal cookiesPerBake = ((decimal)cupGrams + smallSpoonGrams + bigSpoonGrams) *
					Math.Min(Math.Min(flourCups, sugarSpoons), cocoaSpoons) / cookieGrams;

				decimal cookieBoxesMade = Math.Floor(Math.Floor(cookiesPerBake / cookiesPerBox));
				Console.WriteLine($"Boxes of cookies: {cookieBoxesMade}");
				totalBoxes += (int)cookieBoxesMade;
			}

			Console.WriteLine($"Total boxes: {totalBoxes}");
		}
	}
}
