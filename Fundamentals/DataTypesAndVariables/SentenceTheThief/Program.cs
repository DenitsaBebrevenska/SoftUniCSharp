namespace SentenceTheThief
{
	internal class Program
	{
		static void Main()
		{
			string type = Console.ReadLine();
			int idAmount = int.Parse(Console.ReadLine());
			long upperBound = GetUpperBound(type);
			long thiefId = 0;
			long currentNumber = long.MinValue;

			for (int i = 0; i < idAmount; i++)
			{
				long currentId = long.Parse(Console.ReadLine());

				if (currentId <= upperBound && currentId > currentNumber)
				{
					currentNumber = currentId;
					thiefId = currentId;
				}
			}

			decimal years = 0;
			if (thiefId < 0)
			{
				years = Math.Ceiling((decimal)thiefId / -128);
			}
			else
			{
				years = Math.Ceiling((decimal)thiefId / 127);
			}

			Console.WriteLine(years == 1 ? $"Prisoner with id {thiefId} is sentenced to {years} year" : 
				$"Prisoner with id {thiefId} is sentenced to {years} years");
		}

		static long GetUpperBound(string type)
		{
			long upperBound;

			if (type == "sbyte")
			{
				upperBound = sbyte.MaxValue;
			}
			else if (type == "int")
			{
				upperBound = int.MaxValue;
			}
			else
			{
				upperBound = long.MaxValue;
			}
			return upperBound;
		}
	}
}