namespace TouristInformation
{
	internal class Program
	{
		static void Main()
		{
			string unit = Console.ReadLine();
			double value = double.Parse(Console.ReadLine());
			string convertedUnit = string.Empty;
			double convertedValue = 0;

			switch (unit)
			{
				case "miles":
					convertedUnit = "kilometers";
					convertedValue = value * 1.6;
					break;
				case "inches":
					convertedUnit = "centimeters";
					convertedValue = value * 2.54;
					break;
				case "feet":
					convertedUnit = "centimeters";
					convertedValue = value * 30;
					break;
				case "yards":
					convertedUnit = "meters";
					convertedValue = value * 0.91;
					break;
				case "gallons":
					convertedUnit = "liters";
					convertedValue = value * 3.8;
					break;
			}

			Console.WriteLine($"{value} {unit} = {convertedValue:F2} {convertedUnit}");
		}
	}
}