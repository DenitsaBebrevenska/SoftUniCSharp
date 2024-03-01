namespace IntervalOfNumbers
{
	internal class Program
	{
		static void Main()
		{
			int number1 = int.Parse(Console.ReadLine());
			int number2 = int.Parse(Console.ReadLine());

			int start = Math.Min(number1, number2);
			int end = Math.Max(number1, number2);

			for (int i = start; i <= end; i++)
			{
				Console.WriteLine(i);	
			}
		}
	}
}