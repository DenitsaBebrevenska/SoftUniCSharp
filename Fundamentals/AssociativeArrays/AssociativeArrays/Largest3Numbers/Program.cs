namespace Largest3Numbers
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers  = Console.ReadLine().Split().Select(int.Parse).ToList();

			foreach (int number in numbers.OrderByDescending(x => x).Take(3))
			{
				Console.Write(number + " ");
			}
		}
	}
}
