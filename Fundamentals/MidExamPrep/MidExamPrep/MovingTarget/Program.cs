namespace MovingTarget
{
	internal class Program
	{
		static void Main()
		{
			List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

			string input;
			while ((input = Console.ReadLine()) != "End")
			{
				string[] command = input.Split().ToArray();
				int index = int.Parse(command[1]);
				int value = int.Parse(command[2]);
				switch (command[0])
				{
					case "Shoot":
						if (!IsInListRange(targets, index))
						{
							continue;
						}

						targets = Shoot(targets, index, value);
						break;
					case "Add":
						if (!IsInListRange(targets, index))
						{
							Console.WriteLine("Invalid placement!");
							continue;
						}

						targets.Insert(index, value);
						break;
					case "Strike":
						if (!IsInListRange(targets, index - value) || !IsInListRange(targets, index + value))
						{
							Console.WriteLine("Strike missed!");
							continue;
						}

						targets.RemoveRange(index - value, value * 2 + 1);
						break;
				}

			}
			Console.WriteLine(string.Join('|', targets));
		}

		static bool IsInListRange(List<int> targets, int index)
		{
			return index >= 0 && index < targets.Count;
		}

		static List<int> Shoot(List<int> targets, int index, int value)
		{
			targets[index] -= value;
			if (targets[index] <= 0)
			{
				targets.RemoveAt(index);
			}
			return targets;
		}
	}
}