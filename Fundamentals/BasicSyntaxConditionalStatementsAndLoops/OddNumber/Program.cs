namespace OddNumber
{
	internal class Program
	{
		static void Main()
		{
			while (true)
			{
				short number = short.Parse(Console.ReadLine());
				if (number % 2 == 0)
				{
					Console.WriteLine("Please write an odd number.");
					continue;
				}

				Console.WriteLine($"The number is: {Math.Abs(number)}");
				break;
			}
		}
	}
}