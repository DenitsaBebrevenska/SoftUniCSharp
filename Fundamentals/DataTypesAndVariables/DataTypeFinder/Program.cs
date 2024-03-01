using System.Runtime.CompilerServices;

namespace DataTypeFinder
{
	internal class Program
	{
		static void Main(string[] args) // looks kinda bad
		{
			string input = Console.ReadLine();
			while (input != "END")
			{ 
				try
				{
					long inputInt = Convert.ToInt64(input);
					Console.WriteLine($"{input} is integer type");
                }
				catch (Exception)
				{
					try
					{
						double inputDouble = Convert.ToDouble(input);
                        Console.WriteLine($"{input} is floating point type");
                    }
					catch (Exception)
					{

						try
						{
							char inputChar = Convert.ToChar(input);
                            Console.WriteLine($"{input} is character type");
                        }
						catch (Exception)
						{
							try
							{
								bool inputBool = Convert.ToBoolean(input);
								Console.WriteLine($"{input} is boolean type");
							}
							catch(Exception)
							{
								Console.WriteLine($"{input} is string type");
							}
						}
					}
				}        

                input = Console.ReadLine();
			}
		}
	}
}