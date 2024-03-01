namespace VariableInHexFormat
{
	internal class Program
	{
		static void Main()
		{
			string numberHexadecimal = Console.ReadLine();

			Console.WriteLine(Convert.ToInt32(numberHexadecimal, 16));
		}
	}
}