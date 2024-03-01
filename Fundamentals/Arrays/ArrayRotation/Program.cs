namespace ArrayRotation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			int rotationNumber = int.Parse(Console.ReadLine());
			for (int rotation = 1; rotation <= rotationNumber; rotation++)
			{
				int savedNumber = numbers[0];
				for (int i = 0; i < numbers.Length; i++)
				{

					if (i == numbers.Length - 1)
					{
						numbers[numbers.Length - 1] = savedNumber;
					}
					else
					{
						numbers[i] = numbers[i + 1];
					}
				}
			}
			string output = string.Join(" ", numbers);
			Console.WriteLine(output);

		}
	}
}