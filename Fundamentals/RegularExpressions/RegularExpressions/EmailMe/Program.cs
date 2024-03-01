namespace EmailMe
{
	internal class Program
	{
		static void Main()
		{
			string[] emailParts = Console.ReadLine().Split('@');
			int firstPartCharSum = emailParts[0].ToCharArray().Sum(c => c);
			int secondPartCharSum = emailParts[1].ToCharArray().Sum(c => c);
			int differenceSum = firstPartCharSum - secondPartCharSum;
			Console.WriteLine(differenceSum >= 0 ? "Call her!" : "She is not the one.");
		}
	}
}
