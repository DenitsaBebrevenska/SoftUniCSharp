using System.Globalization;

namespace MonthPrinter
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int number = int.Parse(Console.ReadLine());

			if (number > 0 && number <= 12)
			{
				string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(number);
				Console.WriteLine(monthName);
			}
			else
			{
                Console.WriteLine("Error!");
            }
		}
	}
}