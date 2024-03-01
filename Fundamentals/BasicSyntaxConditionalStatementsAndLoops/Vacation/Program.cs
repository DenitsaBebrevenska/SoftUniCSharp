namespace Vacation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int amount = int.Parse(Console.ReadLine());
			string type = Console.ReadLine();
			string day = Console.ReadLine();
			double price = 0;
			if (type == "Students")
			{
				if (day == "Friday")
				{ price = 8.45; }
				else if (day == "Saturday")
				{ price = 9.8; }
				else
				{ price = 10.46; }

				if (amount >= 30)
				{ price *= 0.85; }
			}
			else if (type == "Business")
			{
				if(day == "Friday")
				{ price = 10.9; }
				else if (day == "Saturday")
				{ price = 15.6; }
				else
				{ price = 16; }

				if (amount >= 100)
				{ amount -= 10; }
			}
			else
			{
				if (day == "Friday")
				{ price = 15; }
				else if (day == "Saturday")
				{ price = 20; }
				else
				{ price = 22.5; }

				if (amount >= 10 && amount <= 20)
				{ price *= 0.95; }
			}
			double totalPrice = amount * price;

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
	}
}