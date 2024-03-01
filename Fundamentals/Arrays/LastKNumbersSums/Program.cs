namespace LastKNumbersSums
{
	internal class Program
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());
			int k = int.Parse(Console.ReadLine());
			long[] array = new long[n];
			array[0] = 1;

			for (int i = 1; i < n; i++)
			{
				long sum = 0;
				int startIndex = Math.Max(0, i - k);

				for (int j = startIndex; j < i; j++)
				{
					sum += array[j];
				}

				array[i] = sum;
			}

			Console.WriteLine(string.Join(" ", array));
		}
	}
}