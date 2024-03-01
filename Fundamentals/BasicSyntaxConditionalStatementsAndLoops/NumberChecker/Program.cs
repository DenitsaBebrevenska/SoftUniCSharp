namespace NumberChecker
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			try
			{
				int number = int.Parse(input);
				Console.WriteLine("It is a number.");
			}
			catch (Exception)
			{
				Console.WriteLine("Invalid input!");
			}
		}
	}
}