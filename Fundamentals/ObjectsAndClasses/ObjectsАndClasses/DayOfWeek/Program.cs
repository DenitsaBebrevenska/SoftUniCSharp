namespace DayOfWeek
{
	internal class Program
	{
		static void Main()
		{
			int[] date = Console.ReadLine().
				Split('-').
				Select(int.Parse).
				ToArray();

			DateTime dt = new DateTime(date[2], date[1], date[0]);
			Console.WriteLine(dt.DayOfWeek);
		}
	}
}
