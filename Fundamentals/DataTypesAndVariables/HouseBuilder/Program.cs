namespace HouseBuilder
{
	internal class Program
	{
		static void Main()
		{
			long number1 = long.Parse(Console.ReadLine());
			long number2 = long.Parse(Console.ReadLine());

			long totalPrice = 0;

			if (number1 > number2)
			{
				totalPrice = number1 * 10 + number2 * 4;
			}
			else
			{
				totalPrice = number1 * 4 + number2 * 10;
			}

			Console.WriteLine(totalPrice);
		}
	}
}