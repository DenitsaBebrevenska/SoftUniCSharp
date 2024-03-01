namespace TriBitSwitch
{
	internal class Program
	{
		static void Main()
		{
			int number = int.Parse(Console.ReadLine());
			int position = int.Parse(Console.ReadLine());
			// 3 bits starting from position

			int mask = 7 << position;
			number ^= mask;

			Console.WriteLine(number);
		}
	}
}