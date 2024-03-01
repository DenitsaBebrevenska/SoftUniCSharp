namespace BitAtPosition1
{
	internal class Program
	{
		static void Main()
		{
			int number = int.Parse(Console.ReadLine());
			int shiftedNumber = number >> 1;

			int lsb = shiftedNumber & 1;

			Console.WriteLine(lsb);

		}
	}
}