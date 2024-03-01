namespace SpiceMustFlow
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int startingYield = int.Parse(Console.ReadLine());
			int spiceWorkersTake = 26;
			int spiceMined = 0, days = 0;

			while (startingYield >= 100)
			{
				spiceMined += (startingYield - spiceWorkersTake);
				days++;
				startingYield -= 10;
			}
			int spiceTotal = spiceMined - spiceWorkersTake;
			if (spiceTotal < 0)
			{
				spiceTotal = 0;
			}
            Console.WriteLine(days);
            Console.WriteLine(spiceTotal);
        }
	}
}