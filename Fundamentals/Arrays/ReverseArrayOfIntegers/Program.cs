namespace ReverseArrayOfIntegers
{
	internal class Program
	{
		static void Main()
		{
			int numberOfLines = int.Parse(Console.ReadLine());
			int[] numbers = new int[numberOfLines];

			for (int i = 0; i < numberOfLines; i++)
			{
				numbers[i] = int.Parse(Console.ReadLine());
			}

			for (int i = numbers.Length - 1; i >= 0; i--)
			{
				Console.Write(numbers[i]+ " ");
			}
		}
	}
}