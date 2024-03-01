namespace BinaryDigitsCount
{
	internal class Program
	{
		static void Main()
		{
			int positiveInteger = int.Parse(Console.ReadLine());
			int binaryDigit = int.Parse(Console.ReadLine());
			int count = 0;
			while (positiveInteger > 0)
			{
				int remainder = positiveInteger % 2;
				if (remainder == binaryDigit)
				{
					count++;
				}

				positiveInteger /= 2;

			}

			Console.WriteLine(count);
		}
	}
}