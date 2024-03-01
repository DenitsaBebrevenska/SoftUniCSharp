namespace ExchangeVariableValues
{
	internal class Program
	{
		static void Main()
		{
			int a = 5;
			int b = 10;

			Console.WriteLine("Before:");
			Console.WriteLine($"a = {a}");
			Console.WriteLine($"b = {b}");

			int temp = a;
			a = b;
			b = temp;

			// or tuple (b, a) = (a, b);

			Console.WriteLine("After:");
			Console.WriteLine($"a = {a}");
			Console.WriteLine($"b = {b}");
		}
	}
}