namespace MakeAWord
{
	internal class Program
	{
		static void Main()
		{
			int number = int.Parse(Console.ReadLine());
			string message = string.Empty;

			for (int i = 0; i < number; i++)
			{
				message += Console.ReadLine()[0];
			}

			Console.WriteLine($"The word is: {message}");
		}
	}
}