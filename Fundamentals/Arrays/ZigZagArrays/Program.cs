namespace ZigZagArrays
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int[] array1 = new int[n];
			int[] array2 = new int[n];
			int counter = 1;
			for (int i = 0; i < n; i++)
			{
				int[] currentNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
				if (counter % 2 != 0)
				{
					array1[i] = currentNumbers[0];
					array2[i] = currentNumbers[1];
				}
				else
				{
					array1[i] = currentNumbers[1];
					array2[i] = currentNumbers[0];
				}
				counter++;
			}
			string output1 = string.Join(" ", array1);
			string output2 = string.Join(" ", array2);
            Console.WriteLine(output1);
            Console.WriteLine(output2);


        }
	}
}