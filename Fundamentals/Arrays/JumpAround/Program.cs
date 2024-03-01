namespace JumpAround
{
	internal class Program
	{
		static void Main()
		{
			int[] numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToArray();
			int sum = numbers[0];
			int currentPosition = 0;
			int jumpPower = numbers[currentPosition];
			while (true)
			{
				if (IsValidIndex(currentPosition + jumpPower, numbers))
				{
					currentPosition = currentPosition + jumpPower;
					jumpPower = numbers[currentPosition];
				}
				else if(IsValidIndex(currentPosition - jumpPower, numbers))
				{
					currentPosition = currentPosition - jumpPower;
					jumpPower = numbers[currentPosition];
				}
				else
				{
					break;
				}

				sum += jumpPower;

			}

			Console.WriteLine(sum);
		}

		static bool IsValidIndex(int index, int[] array)
		{
			return index >= 0 && index < array.Length;
		}
	}
}
