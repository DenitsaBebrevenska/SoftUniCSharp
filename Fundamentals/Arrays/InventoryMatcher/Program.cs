namespace InventoryMatcher
{
	internal class Program
	{
		static void Main()
		{
			string[] products = Console.ReadLine().Split();
			string[] quantity = Console.ReadLine().Split();
			string[] price = Console.ReadLine().Split();
			string input;

			while ((input = Console.ReadLine()) != "done")
			{
				string product = input;
				int indexArrays = Array.IndexOf(products, product);
				Console.WriteLine($"{product} costs: {price[indexArrays]}; Available quantity: {quantity[indexArrays]}");
			}
		}
	}
}
