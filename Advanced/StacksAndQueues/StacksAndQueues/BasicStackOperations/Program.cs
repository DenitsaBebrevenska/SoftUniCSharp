namespace BasicStackOperations
{
	internal class Program
	{
		static void Main()
		{
			int[] operationArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int pushElements = operationArgs[0];
			int popElements = operationArgs[1];
			int findElement = operationArgs[2];

			Stack<int> stack = new Stack<int>(numbers.Take(pushElements));

			for (int i = 0; i < popElements; i++)
			{
				stack.Pop();
			}

			if (stack.Count == 0)
			{
				Console.WriteLine(0);
			}
			else
			{
				bool elementFound = stack.Contains(findElement);
				Console.WriteLine(elementFound ? "true" : $"{stack.Min()}");
			}
		}
	}
}
