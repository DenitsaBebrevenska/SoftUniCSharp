namespace StoreBoxes
{
	internal class Program
	{
		static void Main()
		{
			string input;
			List<Box> boxes = new List<Box>();
			while ((input = Console.ReadLine()) != "end")
			{
				string[] tokensProduct = input.Split();
				string serialNumber = tokensProduct[0];
				string itemName = tokensProduct[1];
				int quantity = int.Parse(tokensProduct[2]);
				decimal price = decimal.Parse(tokensProduct[3]);

				Item item = new Item(itemName, price);
				boxes.Add(new Box(serialNumber, item, quantity));
			}
			foreach (Box box in boxes.OrderByDescending(b => b.PricePerBox))
			{
				Console.WriteLine(box.SerialNumber);
				Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.Quantity}");
				Console.WriteLine($"-- ${box.PricePerBox:F2}");
			}
		}

	}
}