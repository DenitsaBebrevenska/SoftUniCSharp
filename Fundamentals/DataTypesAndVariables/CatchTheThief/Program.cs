namespace CatchTheThief
{
	internal class Program
	{
		static void Main()
		{
			string type = Console.ReadLine();
			int idAmount = int.Parse(Console.ReadLine());
			long upperBound = GetUpperBound(type);
			string thiefId = string.Empty;
			long currentNumber = long.MinValue;

			for (int i = 0; i < idAmount; i++)
			{
				long currentId = long.Parse(Console.ReadLine());

				if (currentId <= upperBound && currentId > currentNumber)
				{
					currentNumber = currentId;
					thiefId = currentId.ToString();
				}
			}

			Console.WriteLine(thiefId);
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