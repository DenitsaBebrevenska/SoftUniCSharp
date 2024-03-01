namespace MaximumAndMinimumElement
{
	internal class Program
	{
		static void Main()
		{
			uint queryCount = uint.Parse(Console.ReadLine());
			Stack<int> numbers = new Stack<int>();

			for (uint i = 0; i < queryCount; i++)
			{
				string[] queryArgs = Console.ReadLine().Split();
				string query = queryArgs[0];

				switch (query)
				{
					case "1":
						numbers.Push(int.Parse(queryArgs[1]));
						break;
					case "2":
						numbers.Pop();
						break;
					case "3":
						if (numbers.Count > 0)
						{
							Console.WriteLine(numbers.Max());
						}
						break;
					case "4":
						if (numbers.Count > 0)
						{
							Console.WriteLine(numbers.Min());
						}
						break;
				}
			}

			Console.WriteLine(string.Join(", ", numbers));
		}
	}
}
