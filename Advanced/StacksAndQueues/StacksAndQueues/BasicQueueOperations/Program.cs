namespace BasicQueueOperations
{
	internal class Program
	{
		static void Main()
		{
			int[] operationArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int enqueueElement = operationArgs[0];
			int dequeueElement = operationArgs[1];
			int findElement = operationArgs[2];

			Queue<int> queue = new Queue<int>(numbers.Take(enqueueElement));

			for (int i = 0; i < dequeueElement; i++)
			{
				queue.Dequeue();
			}

			if (queue.Count == 0)
			{
				Console.WriteLine(0);
			}
			else
			{
				bool elementFound = queue.Contains(findElement);
				Console.WriteLine(elementFound ? "true" : $"{queue.Min()}");
			}
		}
	}
}
