namespace X
{
	internal class Program
	{
		static void Main()
		{
			int number = int.Parse(Console.ReadLine());

			for (int i = 0; i < number; i++)
			{
				for (int j = 0; j < number; j++)
				{
					if (i == j || i == number - 1 - j)
					{
						Console.Write("x");
					}
					else
					{
						Console.Write(" ");
					}
				}

				Console.WriteLine();
			}
		}
	}
}