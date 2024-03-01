namespace T7ribonacciSequence
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int num = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(" ", GetTribonacciSequence(num)));
        }
		static long[] GetTribonacciSequence(int num)
		{
			long[] sequence = new long[num];

			sequence[0] = 1;
			if (num == 1)
			{ return sequence; }

			sequence[1] = 1;
			if(num == 2)
			{ return sequence; }

			sequence[2] = 2;
			for (int i = 3; i < num; i++)
			{
				sequence[i] = sequence[i - 1] + sequence[i - 2] + sequence[i - 3];
			}
			return sequence;
		}
	}
}