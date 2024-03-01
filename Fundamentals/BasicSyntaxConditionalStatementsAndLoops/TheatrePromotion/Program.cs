namespace TheatrePromotion
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string day = Console.ReadLine();
			int age = int.Parse(Console.ReadLine());
			bool isValidAge = true;

			int ticketPrice = 0;
			if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
			{
				if (day == "Weekday")
				{
					ticketPrice = 12;
				}
				else if (day == "Weekend")
				{
					ticketPrice = 15;
				}
				else
				{
					if (age >= 0 && age <= 18)
					{
						ticketPrice = 5;
					}
					else 
					{
						ticketPrice = 10;
					}
				}
			}
			else if (age > 18 && age <= 64)
			{
				if (day == "Weekday")
				{
					ticketPrice = 18;
				}
				else if (day == "Weekend")
				{
					ticketPrice = 20;
				}
				else
				{
					ticketPrice = 12;
				}
			}
			else
			{
                Console.WriteLine("Error!");
				isValidAge = false;
            }
			if (isValidAge)
			{
                Console.WriteLine($"{ticketPrice}$");
            }
        }
	}
}