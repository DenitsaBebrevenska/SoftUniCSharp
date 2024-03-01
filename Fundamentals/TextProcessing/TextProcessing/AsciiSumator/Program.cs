namespace AsciiSumator
{
	internal class Program
	{
		static void Main()
		{
			char firstChar = Console.ReadLine()[0];
			char secondChar = Console.ReadLine()[0];
			char[] chars = Console.ReadLine().ToCharArray();
			int sum = 0;

			for (int i = 0; i < chars.Length; i++)
			{
				if (chars[i] > firstChar && chars[i] < secondChar)
				{
					sum += chars[i];
				}
			}

			Console.WriteLine(sum);

		}
	}
}