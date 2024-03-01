namespace TrainingHallEquipment
{
	internal class Program
	{
		static void Main()
		{
			double budget = double.Parse(Console.ReadLine());
			byte numberOfItems = byte.Parse(Console.ReadLine());
			double cartTotal = 0;

			for (int i = 0; i < numberOfItems; i++)
			{
				string item = Console.ReadLine();
				double price = double.Parse(Console.ReadLine());
				ushort count = ushort.Parse(Console.ReadLine());

				cartTotal += count * price;

				if (count > 1)
				{
					item += 's';
				}
				Console.WriteLine($"Adding {count} {item} to cart.");
			}

			Console.WriteLine($"Subtotal: ${cartTotal:F2}");

			Console.WriteLine(budget - cartTotal >= 0 ? $"Money left: ${budget - cartTotal:F2}" : 
				$"Not enough. We need ${cartTotal - budget:F2} more.");
		}
	}
}