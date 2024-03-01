namespace MiddleCharacters
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			PrintMiddleChar(input);
		}
		static void PrintMiddleChar(string input)
		{
			int textLenght = input.Length;
			string middle = "";
			if (textLenght % 2 == 0)
			{
				middle += input[textLenght / 2 - 1];
				middle += input[textLenght / 2 ];
				Console.WriteLine(middle);
			}
			else
			{
				middle += input[textLenght / 2 ];
				Console.WriteLine(middle);
			}
		}
	}
}