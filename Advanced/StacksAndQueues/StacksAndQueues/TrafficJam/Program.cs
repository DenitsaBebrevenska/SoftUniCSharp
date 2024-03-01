namespace TrafficJam
{
	internal class Program
	{
		static void Main()
		{
			uint carsPerGreenLight = uint.Parse(Console.ReadLine());
			string input;
			uint carPassed = 0;
			Queue<string> carQueue = new Queue<string>();

			while ((input = Console.ReadLine()) != "end")
			{
				switch (input)
				{
					case "green":

						for (int i = 0; i < carsPerGreenLight && carQueue.Count > 0; i++)
						{
							Console.WriteLine($"{carQueue.Dequeue()} passed!");
							carPassed++;
						}

						break;
					default:
						carQueue.Enqueue(input);
						break;
				}
			}

			Console.WriteLine($"{carPassed} cars passed the crossroads.");
		}
	}
}
