namespace Hello__Name_
{
	internal class Program
	{
		static void Main()
		{
			PrintGreeting(Console.ReadLine());
		}

		static void PrintGreeting(string name)
		{
			Console.WriteLine($"Hello, {name}!");
		}
	}
}
