namespace MaxMethod
{
	internal class Program
	{
		static void Main()
		{
			int a = int.Parse(Console.ReadLine());
			int b = int.Parse(Console.ReadLine());
			int c = int.Parse(Console.ReadLine());
			PrintTheBiggestNumber(a, b, c);
		}

		static int GetMax(int a, int b)
		{
			return a < b ? b : a;
		}

		static void PrintTheBiggestNumber(int a, int b, int c)
		{
			int biggestNumber = GetMax(GetMax(a, b), c);
			Console.WriteLine(biggestNumber);
		}
	}
}
