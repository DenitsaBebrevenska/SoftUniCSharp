namespace BooleanVariable
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();

			Console.WriteLine(Convert.ToBoolean(input) ? "Yes" : "No");
		}
	}
}