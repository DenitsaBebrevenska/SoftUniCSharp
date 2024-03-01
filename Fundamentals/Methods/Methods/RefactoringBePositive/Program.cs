using System;
using System.Linq;
namespace RefactoringBePositive
{
	internal class Program
	{
		static void Main()
		{
			int countSequences = int.Parse(Console.ReadLine());

			for (int i = 0; i < countSequences; i++)
			{
				int[] numbers = Console.ReadLine().
					Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).
					Select(int.Parse).
					ToArray();

				bool found = false;

				for (int j = 0; j < numbers.Length; j++)
				{
					int currentNum = numbers[j];

					if (currentNum >= 0)
					{
						Console.Write(currentNum + " ");
						found = true;
					}
					else
					{
						if (j + 1 > numbers.Length - 1)
						{
							break;
						}

						currentNum += numbers[j + 1];

						if (currentNum >= 0)
						{
							Console.Write(currentNum + " ");
							found = true;
						}

						j++;
					}
				}

				if (!found)
				{
					Console.WriteLine("(empty)");
				}
				else
				{
					Console.WriteLine();
				}
			}
		}
	}
}