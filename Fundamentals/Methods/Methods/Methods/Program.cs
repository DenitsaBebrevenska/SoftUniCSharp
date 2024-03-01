namespace Methods
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int input = int.Parse(Console.ReadLine());
			CheckInt(input);
		}
		static void CheckInt(int number)
		{
			if (number > 0)
			{
				Console.WriteLine($"The number {number} is positive.");
			}
			else if (number < 0)
			{
				Console.WriteLine($"The number {number} is negative.");
			}
			else
			{
				Console.WriteLine($"The number {number} is zero.");
			}
		}
	}
}