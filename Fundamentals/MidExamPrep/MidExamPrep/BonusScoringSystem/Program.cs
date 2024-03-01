namespace BonusScoringSystem
{
	internal class Program
	{
		static void Main()
		{
			int students = int.Parse(Console.ReadLine());
			int lectures = int.Parse(Console.ReadLine());
			int bonus = int.Parse(Console.ReadLine());

			int maxAttendance = 0;
			double maxBonus = 0;
			for (int i = 1; i <= students; i++)
			{
				int attendance = int.Parse(Console.ReadLine());
				//{total bonus} = {student attendances} / {course lectures} * (5 + {additional bonus})
				double studentBonus = (double)attendance / lectures * (5 + bonus);
				if (studentBonus > maxBonus)
				{
					maxBonus = studentBonus;
					maxAttendance = attendance;
				}
			}

			Console.WriteLine($"Max Bonus: {Math.Round(maxBonus)}.");
			Console.WriteLine($"The student has attended {maxAttendance} lectures.");
		}
	}
}