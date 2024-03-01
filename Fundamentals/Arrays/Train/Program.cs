namespace Train
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int numberOfWagons = int.Parse(Console.ReadLine());
			int[] passangers = new int[numberOfWagons];
			int sum = 0;
			for (int i = 0; i < numberOfWagons; i++)
			{
				passangers[i] = int.Parse(Console.ReadLine());
				sum += passangers[i];
			}
			foreach (int passanger in passangers)
			{
                Console.Write(passanger + " ");
            }
            Console.WriteLine();
            Console.Write(sum);
		}
	}
}