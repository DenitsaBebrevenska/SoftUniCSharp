namespace FastFood
{
	internal class Program
	{
		static void Main()
		{
			ushort foodQuantity = ushort.Parse(Console.ReadLine());
			Queue<ushort> orders = new Queue<ushort> (Console.ReadLine().Split().Select(ushort.Parse));
			Console.WriteLine(orders.Max());

			while (orders.Count > 0)
			{
				if (foodQuantity - orders.Peek() >= 0)
				{
					foodQuantity -= orders.Dequeue();
				}
				else
				{
					Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
					return;
				}
			}

			Console.WriteLine("Orders complete");
		}
	}
}

