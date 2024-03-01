namespace BeerKegs
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); // n - number of kegs
			string biggestKeg = string.Empty;
			double biggestVolume = 0;
			for (int i = 1; i <= n; i++)
			{
				string typeOfKeg = Console.ReadLine();
				double radius = double.Parse(Console.ReadLine());
				int height = int.Parse(Console.ReadLine());
				//π * r^2 * h 
				double volume = Math.PI * Math.Pow(radius, 2) * height;
				if (volume > biggestVolume)
				{
					biggestVolume = volume;
					biggestKeg = typeOfKeg;
				}
			}
            Console.WriteLine(biggestKeg);
        }
	}
}