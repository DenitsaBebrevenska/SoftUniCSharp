namespace BackIn30Minutes
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int hours = int.Parse(Console.ReadLine());
			int minutes = int.Parse(Console.ReadLine());


			//if (minutes < 30)
			//{
			//	minutes += 30;
			//	Console.WriteLine($"{hours}:{minutes}");
			//}
			//else
			//{

			//	minutes -= 30;
			//	hours += 1;
			//	if (hours > 23)
			//	{
			//		hours = 0;
			//	}

			//	if (minutes <= 9)
			//	{
			//		Console.WriteLine($"{hours}:0{minutes}");
			//	}
			//	else
			//	{
			//		Console.WriteLine($"{hours}:{minutes}");
			//	}
			minutes += 30;
			if (minutes >= 60)
			{
				hours++;
				minutes -= 60;

				if (hours > 23)
				{
					hours = 0;
				}
			}
            Console.WriteLine($"{hours}:{minutes:D2}");

        }
	}
}