namespace GreaterOfTwoValues
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string type = Console.ReadLine();
			string input1 = Console.ReadLine();
			string input2 = Console.ReadLine();
			
			if (type == "int")
			{
				int number1 = int.Parse(input1);
				int number2 = int.Parse(input2);
				int result = GetMax(number1, number2);
                Console.WriteLine(result);
            }
			else if (type == "char")
			{
				char char1 = input1[0];
				char char2 = input2[0];
				char result = GetMax(char1, char2);
                Console.WriteLine(result);

            }
			else if (type == "string")
			{
				string result = GetMax(input1, input2);
                Console.WriteLine(result);
            }
        }
		static int GetMax(int number1, int number2)
		{
			if (number1 > number2)
			{
				return number1;
			}
			else
			{
				return number2;
			}
		}
		static char GetMax(char char1, char char2)
		{
			if (char1 > char2)
			{
				return char1;
			}
			else
			{
				return char2;
			}
		}
		static string GetMax(string string1, string string2)
		{
			if (string1.CompareTo(string2) > 0)
			{
				return string1;
			}
			else
			{
				return string2;
			}
		}
	}
}