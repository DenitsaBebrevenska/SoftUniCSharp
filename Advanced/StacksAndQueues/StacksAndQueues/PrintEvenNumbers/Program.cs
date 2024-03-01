namespace PrintEvenNumbers
{
	internal class Program
	{
		static void Main()
		{
			//must use queue
			Queue<int> numbers = new Queue<int>(Console.ReadLine().
				Split().
				Select(int.Parse).
				Where(x => x % 2 == 0));
			Console.WriteLine(string.Join(", ", numbers));
			//too lazy to use Dequeue
		}
	}
}
