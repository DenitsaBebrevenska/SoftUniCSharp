namespace ListOfProducts
{
	internal class Program
	{
		static void Main()
		{
			int numberOfProducts = int.Parse(Console.ReadLine());
			List<string> products = new List<string>();	
			List<string> numberedProducts = new List<string>();
			for (int i = 1; i <= numberOfProducts ; i++)
			{
				products.Add(Console.ReadLine());
			}
			products.Sort();

			for (int i = 1; i <= numberOfProducts; i++)
			{
				numberedProducts.Add($"{i}." + products[i - 1]);
				Console.WriteLine(numberedProducts[i - 1]);
			}

			
		}
	}
}