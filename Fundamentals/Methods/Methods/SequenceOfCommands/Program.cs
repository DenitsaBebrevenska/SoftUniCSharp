namespace SequenceOfCommands
{
	internal class Program
	{
		private const char ArgumentsDelimiter = ' ';
		public static void Main()
		{
			int sizeOfArray = int.Parse(Console.ReadLine());

			long[] array = Console.ReadLine()
				.Split(ArgumentsDelimiter)
				.Select(long.Parse)
				.ToArray();

			string command;
			while ((command = Console.ReadLine())!= "stop")
			{
				string[] line = command.Split(ArgumentsDelimiter);
				long[] args = new long[2];

				if (line[0].Equals("add") ||
				    line[0].Equals("subtract") ||
				    line[0].Equals("multiply"))
				{
					args[0] = long.Parse(line[1]);
					args[1] = long.Parse(line[2]);
				}

				array = PerformAction(array, line[0], args);

				PrintArray(array);
				Console.WriteLine();
			}
		}

		static long[] PerformAction(long[] array, string action, long[] args)
		{
			long position = args[0] - 1;
			long value = args[1];

			switch (action)
			{
				case "multiply":
					array[position] *= value;
					break;
				case "add":
					array[position] += value;
					break;
				case "subtract":
					array[position] -= value;
					break;
				case "lshift":
					ArrayShiftLeft(array);
					break;
				case "rshift":
					ArrayShiftRight(array);
					break;
			}
			return array;
		}

		private static void ArrayShiftRight(long[] array)
		{
			long temp = array[^1];
			for (int i = array.Length - 1; i >= 1; i--)
			{
				array[i] = array[i - 1];
			}
			array[0] = temp;
		}

		private static void ArrayShiftLeft(long[] array)
		{
			long temp = array[0];
			for (int i = 0; i < array.Length - 1; i++)
			{
				array[i] = array[i + 1];
			}
			array[^1] = temp;
		}

		private static void PrintArray(long[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(array[i] + " ");
			}
		}
	}
}
