using System.Globalization;
using System.Text;

namespace MusicHub
{
    using Data;
    using Initializer;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Problem 02
            //int producerId = 9;
            //Console.WriteLine(ExportAlbumsInfo(context, producerId));

            //Problem 03
            int duration = 4;
            Console.WriteLine(ExportSongsAboveDuration(context, duration));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .ToArray() //because of the calculated property, could be fixed in latest versions of EF but Judge uses 6.0.1
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.Writer.Name)
                        .Select(s => new
                        {
                            SongName = s.Name,
                            s.Price,
                            WriterName = s.Writer.Name
                        })
                        .ToArray(),
                    a.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb
                    .AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                int songCount = 0;
                foreach (var song in album.Songs)
                {
                    sb
                        .AppendLine($"---#{++songCount}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price:F2}")
                        .AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .ToArray() //again cannot be translated, so we materialise the data
                .Where(s => (int)s.Duration.TotalSeconds > duration)
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer.Name)
                .Select(s => new
                {
                    s.Name,
                    Performers = s.SongPerformers
                        .Select(p => new
                        {
                            PerformerFullName = $"{p.Performer.FirstName} {p.Performer.LastName}"
                        })
                        .OrderBy(p => p.PerformerFullName)
                        .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    s.Duration
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            int songCount = 0;

            foreach (var song in songs)
            {
                sb
                    .AppendLine($"-Song #{++songCount}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.WriterName}");

                foreach (var performer in song.Performers)
                {
                    sb
                        .AppendLine($"---Performer: {performer.PerformerFullName}");
                }

                sb
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
