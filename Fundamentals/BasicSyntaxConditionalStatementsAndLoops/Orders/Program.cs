namespace Orders
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); // n-number of orders
			double sum = 0;
			for (int i = 0; i < n; i++) 
			{
				double capsulePrice = double.Parse(Console.ReadLine());
				int days = int.Parse(Console.ReadLine());
				int capsuleCount = int.Parse(Console.ReadLine());
				double currentAmount = (days * capsuleCount) * capsulePrice;
				sum += currentAmount;
				Console.WriteLine($"The price for the coffee is: ${currentAmount:F2}");
			}
            Console.WriteLine($"Total: ${sum:F2}");
        }
	}
}