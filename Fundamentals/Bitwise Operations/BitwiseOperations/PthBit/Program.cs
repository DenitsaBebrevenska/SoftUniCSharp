namespace PthBit
{
	internal class Program
	{
		static void Main()
		{
			int number = int.Parse(Console.ReadLine());
			int position = int.Parse(Console.ReadLine());

			int shiftedNumer = number >> position;
			int lsb = shiftedNumer & 1;

			Console.WriteLine(lsb);
		}
	}
}