namespace FastPrimeChecker
{
	internal class Program
	{
		static void Main()
		{
			//to refactor: this is the original
			//int ___Do___ = int.Parse(Console.ReadLine());
			//for (int DAVIDIM = 0; DAVIDIM <= ___Do___; DAVIDIM++)
			//{    bool TowaLIE = true;
			//	for (int delio = 2; delio <= Math.Sqrt(DAVIDIM); delio++)
			//	{
			//		if  (DAVIDIM % delio == 0)
			//		{
			//			TowaLIE = false;
			//			break;
			//		}
			//	}
			//	Console.WriteLine($"{DAVIDIM} -> {TowaLIE}");
			//}

			int numbersRange = int.Parse(Console.ReadLine());

			for (int i = 2; i <= numbersRange; i++)
			{
				bool isPrime = true;

				for (int factor = 2; factor <= Math.Sqrt(i); factor++)
				{
					if (i % factor == 0)
					{
						isPrime = false;
						break;
					}
				}
				Console.WriteLine($"{i} -> {isPrime}");
			}


		}
	}
}