namespace DataTypeFinderABetterSolution
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string input  = Console.ReadLine();
			int inputInt;
			double inputDouble;
			char inputChar;
			bool inputBool;
			while (input != "END")
			{
				if (int.TryParse(input, out inputInt))
				{
					Console.WriteLine($"{input} is integer type");
				}
				else if (double.TryParse(input, out inputDouble))
				{
					Console.WriteLine($"{input} is floating point type");
				}
				else if (bool.TryParse(input, out inputBool))
				{
					Console.WriteLine($"{input} is boolean type");
				}
				else if (char.TryParse(input, out inputChar))
				{
					Console.WriteLine($"{input} is character type");
				}
				else
				{
                    Console.WriteLine($"{input} is string type");

				}
				input = Console.ReadLine();
			}
		}
	}
}