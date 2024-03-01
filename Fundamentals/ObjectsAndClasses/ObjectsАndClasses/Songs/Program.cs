namespace Songs
{
	internal class Program
	{
		static void Main()
		{
			int songsAmount = int.Parse(Console.ReadLine());
			List<Song> songs = new();

			for (int i = 0; i < songsAmount; i++)
			{
				string[] tokens = Console.ReadLine().Split('_');
				Song currentSong = new Song();
				currentSong.TypeList = tokens[0];
				currentSong.Name = tokens[1];
				currentSong.Time = tokens[2];
				songs.Add(currentSong);

			}

			string type = Console.ReadLine();

			if (type == "all")
			{
				foreach (Song song in songs)
				{
					Console.WriteLine(song.Name);
				}
			}
			else
			{
				foreach (var song in songs.Where(song => song.TypeList == type))
				{
					Console.WriteLine(song.Name);
				}
			}
		}
	}
}