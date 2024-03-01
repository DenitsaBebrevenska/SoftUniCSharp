namespace GameOfNumbers
{
	internal class Program
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());
			int m = int.Parse(Console.ReadLine());
			int magicNumber = int.Parse(Console.ReadLine());
			int counter = 0;
			string lastMagicCombination = "";

			for (int i = n; i <= m; i++)
			{
				for (int j = n; j <= m; j++)
				{
					int sum = i +j;
					counter++;

					if (sum == magicNumber)
					{
						lastMagicCombination = $"{i} + {j} = {sum}";
					}
				}
			}
			Console.WriteLine(lastMagicCombination == "" ? $"{counter} combinations - neither equals {magicNumber}":
				 $"Number found! {lastMagicCombination}");
		}
	}
}