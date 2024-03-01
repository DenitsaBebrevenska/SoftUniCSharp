namespace RefactoringPrimeChecker
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int endRange = int.Parse(Console.ReadLine());
			for (int i = 2; i <= endRange; i++)
			{
				bool isPrime = true;
				for (int k = 2; k < i; k++)
				{
					if (i % k == 0)
					{
						isPrime = false;
						break;
					}
				}
				string outputText = isPrime.ToString().ToLower();
				Console.WriteLine("{0} -> {1}", i, outputText);
			}
			}
	}
}