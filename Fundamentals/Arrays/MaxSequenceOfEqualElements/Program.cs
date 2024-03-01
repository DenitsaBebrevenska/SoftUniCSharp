namespace MaxSequenceOfEqualElements
{
	internal class Program
	{
		static void Main(string[] args)
		{	
			int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			int sequenceNumber = 0;
			int counter = 1, maxCount = 1;
	
			for (int i = 0; i < numbers.Length-1; i++)
			{
				if (numbers[i] == numbers[i+1])
				{
					counter++;
					if (counter > maxCount)
					{
						maxCount = counter;
						sequenceNumber = numbers[i];				
					}
				}
				else
				{
					counter = 1;
				}
			}
			for (int i = 1; i <= maxCount; i++)
			{
                Console.Write(sequenceNumber + " ");
            }
        }
	}
}