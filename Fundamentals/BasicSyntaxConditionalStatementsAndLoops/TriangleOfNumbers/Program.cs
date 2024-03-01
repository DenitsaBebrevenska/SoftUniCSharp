namespace TriangleOfNumbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int number = int.Parse(Console.ReadLine());
			int row = 1;
			
			for (int i = 1; i <= number; i++)
			{
                for (int j = 1; j <= row; j++)
				{
                    Console.Write(row);
					if (j < row)
					{
						Console.Write(" ");
					}
					else
					{
                        Console.WriteLine();
                    }
                }
				row++;
            }
		}
	}
}