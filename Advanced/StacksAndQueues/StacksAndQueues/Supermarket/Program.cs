namespace Supermarket
{
	internal class Program
	{
		static void Main()
		{
			string input;
			Queue<string> customers = new Queue<string>();

			while ((input = Console.ReadLine()) != "End")
			{
				switch (input)
				{
					case "Paid":
						Console.WriteLine(string.Join("\n", customers));
						customers.Clear();
						break;
					default:
						customers.Enqueue(input);
						break;
				}
			}
			
			Console.WriteLine(customers.Count + " people remaining.");
		}
	}
}
