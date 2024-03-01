namespace CondenseArrayToNumber
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			
			while (input.Length > 1)
			{
				int[] condensed = new int[input.Length - 1];
				for (int i = 0; i < condensed.Length; i++)
				{
					condensed[i] = input[i] + input[i + 1];
				}
				input = condensed;
			}
			Console.WriteLine(input[0]);
        }
	}
}