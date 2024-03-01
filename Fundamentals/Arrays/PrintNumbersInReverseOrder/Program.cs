namespace PrintNumbersInReverseOrder
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int input  = int.Parse(Console.ReadLine());
			int[] numbers = new int[input];
			for (int i = numbers.Length - 1; i >= 0; i--) // the for cycles can be switched up, saving the array as is 
			{
				numbers[i] = int.Parse(Console.ReadLine());
			}
			for (int i = 0; i <= numbers.Length - 1; i++) // and printing in reverse by forr
			{
				Console.Write(numbers[i] + " ");
            }
        }
	}
}