namespace DebitCardNumber
{
	internal class Program
	{
		static void Main()
		{
			int number1 = int.Parse(Console.ReadLine());
			int number2 = int.Parse(Console.ReadLine());
			int number3 = int.Parse(Console.ReadLine());
			int number4 = int.Parse(Console.ReadLine());

			Console.WriteLine($"{number1:D4} {number2:D4} {number3:D4} {number4:D4}");

		}
	}
}