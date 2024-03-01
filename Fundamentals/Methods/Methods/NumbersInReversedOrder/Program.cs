namespace NumbersInReversedOrder
{
	internal class Program
	{
		static void Main()
		{
			PrintReversedNumber(Console.ReadLine());
		}

		static void PrintReversedNumber(string number)
		{
			string reversed = string.Join(string.Empty,number.ToCharArray().Reverse());
			Console.WriteLine(reversed);
		}
	}
}
