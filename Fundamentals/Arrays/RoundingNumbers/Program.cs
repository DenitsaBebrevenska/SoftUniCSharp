namespace RoundingNumbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double[] inputArray = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
			int[] roundedNumbers = new int[inputArray.Length];
			for (int i = 0; i <= inputArray.Length - 1; i++) 
			{
				roundedNumbers[i] = (int)Math.Round(inputArray[i], MidpointRounding.AwayFromZero);
				Console.WriteLine($"{inputArray[i]} => {roundedNumbers[i]}");
            }
			
 		}
	}
}