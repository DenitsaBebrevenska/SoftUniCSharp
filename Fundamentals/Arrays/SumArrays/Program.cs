namespace SumArrays
{
	internal class Program
	{
		static void Main()
		{
			int[] numbers1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int[] numbers2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

			if (numbers1.Length == numbers2.Length)
			{
				for (int i = 0; i < numbers1.Length; i++)
				{
					Console.Write($"{numbers1[i] + numbers2[i]} ");
				}
			}
			else
			{ 
				int[] shortArray = GetTheShorterArray(numbers1, numbers2);
				int[] longArray = GetTheLongerArray(numbers1, numbers2);
				int j = 0;
				for (int i = 0; i < longArray.Length; i++)
				{
					Console.Write($"{longArray[i] + shortArray[j]} ");
					j++;

					if (j == shortArray.Length)
					{
						j = 0;
					}

				}
			}
		}

		static int[] GetTheLongerArray(int[] numbers1, int[] numbers2)
		{
			if (numbers1.Length > numbers2.Length)
			{
				return numbers1;
			}

			return numbers2;
		}

		static int[] GetTheShorterArray(int[] numbers1, int[] numbers2)
		{
			if (numbers1.Length < numbers2.Length)
			{
				return numbers1;
			}

			return numbers2;
		}
	}
}