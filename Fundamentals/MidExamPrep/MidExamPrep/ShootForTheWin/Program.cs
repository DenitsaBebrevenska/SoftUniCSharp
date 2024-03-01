namespace ShootForTheWin
{
	internal class Program
	{
		static void Main()
		{
		     int[] targets = Console.ReadLine().
			     Split().
			     Select(int.Parse).
			     ToArray();

		     string input;
		     int shotTargets = 0;
		     while ((input = Console.ReadLine()) != "End")
		     {
			     int currentIndex = int.Parse(input);
			     if (IsInArrayRange(targets, currentIndex))
			     {
				     if (!IsTargetShot(targets[currentIndex]))
				     {
						 int value = targets[currentIndex];
					     targets[currentIndex] = - 1;
						 shotTargets++;
					     targets = ChangeAvailableTargets(targets, value);
				     }
			     }
		     }

		     Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(' ', targets)}");
		}

		static bool IsInArrayRange(int[] array, int index)
		{
			return index >= 0 && index < array.Length;
		}

		static bool IsTargetShot(int target)
		{
			return target == -1;
		}

		static int[] ChangeAvailableTargets(int[] array, int value)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == -1)
				{
					continue;
				}
				else if (array[i] > value)
				{
					array[i] -= value;
				}
				else if (array[i] <= value)
				{
					array[i] += value;
				}
			}
			return array;
		}
	}
}