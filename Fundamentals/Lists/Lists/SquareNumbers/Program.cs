namespace SquareNumbers
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();
			List<int> squareNumbers = new List<int>();

			foreach (int number in numbers)
			{
				if (Math.Sqrt(number) == (int)Math.Sqrt(number))
				{
					squareNumbers.Add(number);
				}
			}

			foreach (int squareNumber in squareNumbers.OrderByDescending(n => n))
			{
				Console.Write(squareNumber + " ");
			}
		}
	}
}
