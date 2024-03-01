namespace SalesReport
{
	internal class Program
	{
		static void Main()
		{
			List<Sale> saleList = new List<Sale>();
			byte numberOfLines = byte.Parse(Console.ReadLine());

			for (byte i = 0; i < numberOfLines; i++)
			{
				string[] saleArgs = Console.ReadLine().Split();
				string town = saleArgs[0];
				// saleArgs[1] is the product name but that is irrelevant information since it is not stored or used anywhere
				decimal price = decimal.Parse(saleArgs[2]);
				decimal quantity = decimal.Parse(saleArgs[3]);

				int index = saleList.FindIndex(s => s.Town == town);

				if (index == -1)
				{
					saleList.Add(new Sale(town, price * quantity));
				}
				else
				{
					saleList[index].Amount += price * quantity;
				}
			}

			foreach (Sale s in saleList.OrderBy(s => s.Town))
			{
				Console.WriteLine($"{s.Town} -> {s.Amount:F2}");
			}
		}
	}
}
