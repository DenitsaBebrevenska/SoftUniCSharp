namespace PadawanEquipment
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double budget = double.Parse(Console.ReadLine());
			int studentCount = int.Parse(Console.ReadLine());
			double lightsaberPrice = double.Parse(Console.ReadLine());
			double robePrice = double.Parse(Console.ReadLine());
			double beltPrice = double.Parse(Console.ReadLine());

			double lightsaberAmount = studentCount * 1.1;
			int freeBelts = studentCount / 6;

			double expenses = studentCount * robePrice + Math.Ceiling(lightsaberAmount) * lightsaberPrice
				+ (studentCount - freeBelts) * beltPrice;

			if (budget >= expenses)
			{
				Console.WriteLine($"The money is enough - it would cost {expenses:F2}lv.");
			}
			else
			{
                Console.WriteLine($"John will need {expenses - budget:F2}lv more.");
            }
		}
	}
}