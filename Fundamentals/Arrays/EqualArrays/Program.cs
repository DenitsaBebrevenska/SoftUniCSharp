using System.Threading.Channels;

namespace EqualArrays
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] inputLine1 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			int[] inputLine2 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			int sum = 0;
			bool identical = true;
			for (int i = 0; i < inputLine1.Length; i++)
			{
				if (inputLine1[i] == inputLine2[i])
				{
					sum += inputLine1[i];
				}
				else
				{
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
					identical = false;
					break;
                }
			}
			if (identical)
			{
				Console.WriteLine($"Arrays are identical. Sum: {sum}");
			}
		}
	}
}