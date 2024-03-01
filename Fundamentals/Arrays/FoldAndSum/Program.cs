namespace FoldAndSum
{
	internal class Program
	{
		static void Main()
		{
			//numbers as central bottom array
			//left and right upper have each central / 2 length;
			// [ 0 1 2 3 4 5 6 7] - 8 length, central piece has 4 length, the other to - 2 each
			// [ 1 2 3 4 5 6 7 8]
			int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int[] bottomArray = new int[numbers.Length / 2];
			int[] leftArray = new int[bottomArray.Length /2];
			int[] rightArray = new int[bottomArray.Length /2];
			int indexStartBottom = leftArray.Length;
			int indexEndBottom = numbers.Length - leftArray.Length - 1;
			
			bottomArray = PopulateBottomArray(numbers, indexStartBottom, indexEndBottom);
			leftArray = PopulateLeftRightArraysReversed(numbers, indexStartBottom - 1, 0);
			rightArray = PopulateLeftRightArraysReversed(numbers, numbers.Length - 1, indexEndBottom + 1);

			int[] topArray = new int[numbers.Length / 2];
			topArray = PopulateTopArray(leftArray, rightArray);
			
			PrintOutput(bottomArray,topArray);

		}

		static int[] PopulateBottomArray(int[] array, int indexStart, int indexEnd)
		{
			int[] newArray = new int[array.Length / 2];
			int j = 0;
			for (int i = indexStart; i <= indexEnd; i++) 
			{
				newArray[j] = array[i];
				j++;
			}
			return newArray;
		}

		static int[] PopulateLeftRightArraysReversed(int[] array, int indexStart,int indexEnd)
		{
			int[] newArray = new int[array.Length / 4];
			int j = 0;
			for (int i = indexStart; i >= indexEnd; i--) 
			{
				newArray[j] = array[i];
				j++;
			}
			return newArray;
		}

		static int[] PopulateTopArray(int[] leftArray, int[] rightArray)
		{
			int[] newArray = new int[leftArray.Length * 2];
			for (int i = 0; i < leftArray.Length; i++)
			{
				newArray[i] = leftArray[i];
			}

			int j = 0;
			for (int i = newArray.Length / 2; i < newArray.Length; i++)
			{
				newArray[i] = rightArray[j];
				j++;
			}

			return newArray;
		}

		static void PrintOutput(int[] array1, int[] array2)
		{
			int sum = 0;
			for (int i = 0; i < array1.Length; i++)
			{
				sum = array1[i] + array2[i];
				Console.Write(sum + " ");
			}
		}

	}
}