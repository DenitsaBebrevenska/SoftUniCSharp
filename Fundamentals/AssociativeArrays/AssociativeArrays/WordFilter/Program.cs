namespace WordFilter
{
	internal class Program
	{
		static void Main()
		{
			Console.
				ReadLine().
				Split().
				Where(w => w.Length % 2 == 0).
				ToList().
				ForEach(Console.WriteLine);
		}
	}
}