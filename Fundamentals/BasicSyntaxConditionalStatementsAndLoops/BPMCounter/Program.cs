namespace BPMCounter
{
	internal class Program
	{
		static void Main()
		{
			int bpm = int.Parse(Console.ReadLine());
			int numberOfBeats = int.Parse(Console.ReadLine());

			double bars = Math.Round(((double)numberOfBeats / 4), 1);
			double beatsPerSecond = bpm * 1.00 / 60;
			double timeBeats = Math.Floor(numberOfBeats / beatsPerSecond);

			string time = $"0m {timeBeats}s";
			if (timeBeats > 59)
			{
				int minutes = (int)timeBeats / 60;
				int seconds = (int)timeBeats % 60;
				time = $"{minutes}m {seconds}s";
			}

			Console.WriteLine($"{bars} bars - {time}");
		}
	}
}