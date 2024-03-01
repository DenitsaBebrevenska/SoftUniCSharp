namespace ManipulateArray
{
	internal class Program
	{
		static void Main()
		{
			string[] array = Console.ReadLine().Split();
			byte commandCount = byte.Parse(Console.ReadLine());

			for (byte i = 0; i < commandCount; i++)
			{
				string command = Console.ReadLine();

				switch (command)
				{
					case "Reverse":
						array = array.Reverse().ToArray();
						break;
					case "Distinct":
						array = array.Distinct().ToArray();
						break;
					default:
						string[] arguments = command.Split();
						byte index = byte.Parse(arguments[1]);
						string replacement = arguments[2];
						array[index] = replacement;
						break;
				}
			}

			Console.WriteLine(string.Join(", ", array));
		}
	}
}
