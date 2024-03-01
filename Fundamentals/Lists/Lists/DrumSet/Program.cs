using System.Numerics;

namespace DrumSet
{
	internal class Program
	{
		static void Main()
		{
			double savings = double.Parse(Console.ReadLine());
			List<int> drumsetInitialState = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();
			List<int> drumsetCurrentState = new();
			drumsetCurrentState.AddRange(drumsetInitialState);
			string input;
			while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
			{
				int power = int.Parse(input);
				for (int i = 0; i < drumsetCurrentState.Count; i++)
				{
					drumsetCurrentState[i] -= power;
					if (drumsetCurrentState[i] <= 0)
					{
						if (savings >= drumsetInitialState[i] * 3)
						{
							drumsetCurrentState[i] = drumsetInitialState[i];
							savings -= drumsetInitialState[i] * 3;
						}
						else
						{
							drumsetCurrentState.RemoveAt(i);
							drumsetInitialState.RemoveAt(i);
							i--;
						}
					}
				}
			}
            Console.WriteLine(string.Join(' ', drumsetCurrentState));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
	}
}