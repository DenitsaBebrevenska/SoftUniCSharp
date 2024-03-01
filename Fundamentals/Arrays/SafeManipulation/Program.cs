namespace SafeManipulation
{
	internal class Program
	{
		static void Main()
		{
			string[] array = Console.ReadLine().Split();

			string command = Console.ReadLine();
			while (command != "END")
			{
				if (command == "Reverse")
				{
					array = array.Reverse().ToArray();
				}
				else if (command == "Distinct")
				{

					array = array.Distinct().ToArray();
				}
				else if (command.Contains("Replace"))
				{
					string[] arguments = command.Split();
					int index = int.Parse(arguments[1]);
					if (!IsValidIndex(index, array.Length))
					{
						Console.WriteLine("Invalid input!");
					}
					else
					{
						string replacement = arguments[2];
						array[index] = replacement;
					}
				}
				else
				{
					Console.WriteLine("Invalid input!");
				}

				command = Console.ReadLine();
			}

			Console.WriteLine(string.Join(", ", array));
		}

		static bool IsValidIndex(int index, int length)
		{
			return index >= 0 && index < length;
		}
	}
}
