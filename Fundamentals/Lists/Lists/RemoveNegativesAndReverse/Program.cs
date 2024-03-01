namespace RemoveNegativesAndReverse
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();

			 /*
			  The solution when you don`t know the method RemoveAll!
			  * string output = "";
			  
			for (int i = 0; i < numbers.Count; i++)
			{
				if (numbers[i] >= 0)
				{
					output = $"{numbers[i]} " + output;
				}
			}

			Console.WriteLine(output == "" ? "empty" : output);
			 */

			numbers.RemoveAll(n => n < 0);
			if (numbers.Count == 0)
			{
				Console.WriteLine("empty");
			}
			else
			{
				for (int i = numbers.Count - 1; i >= 0; i--)
				{
					Console.Write(numbers[i] + " ");
				}
			}
		}
	}
}