namespace LowerOrUpper
{
	internal class Program
	{
		static void Main(string[] args)
		{
			char input = Console.ReadLine()[0];

			int asciiValue = Convert.ToInt32(input);
			if (asciiValue >= 65 && asciiValue <= 90)
			{
				Console.WriteLine("upper-case");
			}
			else if (asciiValue >= 97 && asciiValue <= 122)
			{
                Console.WriteLine("lower-case");
            }
		}
	}
}