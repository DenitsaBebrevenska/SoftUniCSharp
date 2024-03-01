namespace RotateAndSum
{
	internal class Program
	{
		static void Main()
		{
			int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int numberOfShifts = int.Parse(Console.ReadLine());
			int[] summedArray = new int[numbers.Length];

			for (int i = 0; i < numberOfShifts; i++) //sum the numbers
			{
				summedArray[0] += numbers[^1];

				for (int j = 0; j < numbers.Length - 1; j++)
				{
					summedArray[j + 1] += numbers[j];
				}

				int tempLast = numbers[^1];
				
				for (int j = numbers.Length - 2; j >= 0; j--) //and shift the array
				{
					numbers[j+1] = numbers[j];
				}
				numbers[0] = tempLast;
			}

			Console.WriteLine(string.Join(' ', summedArray));
		}
	}
}