using System.Globalization;

namespace CountWorkingDays
{
	internal class Program
	{
		static void Main()
		{
			CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
			string date1 = Console.ReadLine();
			string date2 = Console.ReadLine();
			DateTime startDate = DateTime.ParseExact(date1, "dd-MM-yyyy", CultureInfo.InvariantCulture);
			DateTime endDate = DateTime.ParseExact(date2, "dd-MM-yyyy", CultureInfo.InvariantCulture);
			

			uint workingDays = 0;

			for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
			{
				DateTime[] officialHolidays = {
					new DateTime(i.Year, 1, 1 ), // New Year Eve 
					new DateTime(i.Year, 3, 3), // Liberation Day 
					new DateTime(i.Year, 5, 1), // Worker’s day 
					new DateTime(i.Year, 5, 6), // Saint George’s Day
					new DateTime(i.Year, 5, 24), // Saints Cyril and Methodius Day 
					new DateTime(i.Year, 9, 6), // Unification Day 
					new DateTime(i.Year, 9, 22), // Independence Day 
					new DateTime(i.Year, 11, 1),// National Awakening Day 
					new DateTime(i.Year, 12 ,24), // Christmas
					new DateTime(i.Year, 12 ,25), // Christmas
					new DateTime(i.Year, 12 ,26) // Christmas
				};

				if (i.DayOfWeek == DayOfWeek.Saturday
				    || i.DayOfWeek == DayOfWeek.Sunday
				    || officialHolidays.Contains(i))
				{
					continue;
				}

				workingDays++;
			}

			Console.WriteLine(workingDays);
		}
	}
}
