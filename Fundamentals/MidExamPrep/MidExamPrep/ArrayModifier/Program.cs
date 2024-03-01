namespace ArrayModifier
{
	internal class Program
	{
		static void Main()
		{
			int[] numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToArray();

			string input;
			while ((input = Console.ReadLine()) != "end")
			{
				string[] tokens = input.Split().ToArray();
				
				switch (tokens[0])
				{
					case "swap":
						int index1 = int.Parse(tokens[1]);
						int index2 = int.Parse(tokens[2]);
						//tuples instead of temp
						(numbers[index1], numbers[index2]) = (numbers[index2], numbers[index1]);
						break;
					case "multiply":
						index1 = int.Parse(tokens[1]);
						index2 = int.Parse(tokens[2]);
						numbers[index1] *= numbers[index2];
						break;
					case "decrease":
						numbers = Decrease(numbers);
						break;
				}
			}

			Console.WriteLine(string.Join(", ", numbers));
		}

		static int[] Decrease(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i]--;
			}
			return array;
		}
	}
}