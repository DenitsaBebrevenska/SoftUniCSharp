namespace LargestCommonEnd
{
	internal class Program
	{
		static void Main()
		{
			string[] firstArray = Console.ReadLine().Split();
			string[] secondArray = Console.ReadLine().Split();
			string[] shorterArray = GetShorterArray(firstArray, secondArray);
			string[] longerArray = GetLongerArray(firstArray, secondArray);

			int frontSimilarItems = 0;
			int hindSimilarItems = 0;

			for (int i = 0; i < shorterArray.Length; i++)
			{
				if (shorterArray[i] == longerArray[i])
				{
					frontSimilarItems++;
				}
			}

			int j = longerArray.Length - 1;
			for (int i = shorterArray.Length - 1; i >= 0; i--)
			{
				if (shorterArray[i] == longerArray[j])
				{
					hindSimilarItems++;
				}

				j--;
			}

			Console.WriteLine(frontSimilarItems > hindSimilarItems ? $"{frontSimilarItems}" : $"{hindSimilarItems}");
		}

		static string[] GetShorterArray(string[] firstArray, string[] secondArray)
		{
			if (firstArray.Length >= secondArray.Length)
			{
				return secondArray;
			}

			return firstArray;
		}
		static string[] GetLongerArray(string[] firstArray, string[] secondArray)
		{
			if (firstArray.Length < secondArray.Length)
			{
				return secondArray;
			}

			return firstArray;
		}
	}
}