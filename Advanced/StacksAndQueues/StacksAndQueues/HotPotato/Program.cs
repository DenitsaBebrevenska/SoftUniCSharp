namespace HotPotato
{
	internal class Program
	{
		static void Main()
		{
			Queue<string> childrenNames = new Queue<string>(Console.ReadLine().Split());
			ushort numberOfPasses = ushort.Parse(Console.ReadLine());
			ushort passCounter = 0;

			while (childrenNames.Count > 1)
			{
				for (ushort i = 0; i < numberOfPasses; i++)
				{
					string currentChild = childrenNames.Dequeue();
					passCounter++;

					if (passCounter == numberOfPasses)
					{
						passCounter = 0;
						Console.WriteLine($"Removed {currentChild}");
						continue;
					}

					childrenNames.Enqueue(currentChild);
				}
			}

			Console.WriteLine($"Last is {childrenNames.Dequeue()}");
		}
	}
}
