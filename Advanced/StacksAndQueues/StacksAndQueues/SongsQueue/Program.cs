namespace SongsQueue
{
	internal class Program
	{
		static void Main()
		{
			Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));
			
			while (songs.Count > 0)
			{
				string input = Console.ReadLine();
				
				if (input.Contains("Play"))
				{
					songs.Dequeue();
				}
				else if (input.Contains("Add"))
				{
					int indexFirstSpace = input.IndexOf(' ');
					string songName = input.Remove(0, indexFirstSpace + 1);

					if (songs.Contains(songName))
					{
						Console.WriteLine($"{songName} is already contained!");
						continue;
					}

					songs.Enqueue(songName);
				}
				else if (input == "Show")
				{
					Console.WriteLine(string.Join(", ", songs));
				}
			}

			Console.WriteLine("No more songs!");
		}
	}
}
