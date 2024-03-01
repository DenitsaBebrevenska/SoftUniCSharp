namespace DataTypes
{
	internal class Program
	{
		static void Main()
		{
			string dataType = Console.ReadLine();
			string input = Console.ReadLine();
			PrintOutput(dataType, input);
		}

		static void PrintOutput(string dataType, string input)
		{
			if (dataType == "int")
			{
				int number = int.Parse(input);
				Console.WriteLine(number * 2);
			}
			else if (dataType == "real")
			{
				double number = double.Parse(input);
				Console.WriteLine($"{number * 1.5 :F2}");
			}
			else
			{
				Console.WriteLine($"${input}$");
			}
		}
	}
}