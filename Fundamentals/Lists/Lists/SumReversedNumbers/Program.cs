namespace SumReversedNumbers
{
	internal class Program
	{
		static void Main()
		{
			string[] numbersAStrings = Console.ReadLine().Split();
			int sum = 0;

			for (int i = 0; i < numbersAStrings.Length; i++)
			{
				string currentString = numbersAStrings[i];
				currentString = string.Concat(currentString.ToCharArray().Reverse());
				sum += int.Parse(currentString);
			}

			Console.WriteLine(sum);
		}
	}
}
