namespace TopIntegers
{
	internal class Program
	{
		static void Main(string[] args)
		{   //0  1  2  3  4  5
			//14 24 3 19 15 17
			// compare current index to all the others to the right of it (+), if bigger than all of them add to an array
			//the last index is always present in the new array regardless 

			int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			string topInts = string.Empty;
			int indexReducer = 0;
			for (int i = 0; i < numbers.Length - 1; i++)  //no need to check the last number
			{
				int isBiggerCount = 0; //this count should go down by one while the index reducer will go up by one
				indexReducer++;
				for (int j = i+1; j < numbers.Length; j++) //loop through all the elements to the right of the element index[i]
				{
					if (numbers[i] > numbers[j])
					{
						isBiggerCount++;
					}
					else //no need to continue the loop if even once the number is not bigger
					{
						break;
					}
					if (isBiggerCount == numbers.Length - indexReducer) //if it was the bigger number for all the numbers to the right
					{
						topInts += numbers[i] + " "; 
					}
				}
				
			}
			topInts += numbers[numbers.Length - 1]; //always add the last element
            Console.WriteLine(topInts);
        }
	}
}